using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Tekla.Structures;
using Tekla.Structures.Datatype;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace MuggleTeklaPlugins.Common {
    /// <summary>
    /// 不支持的截面或不支持的截面参数
    /// </summary>
    public class UnAcceptableProfile : Exception {
        private readonly string _message;
        public UnAcceptableProfile() { }
        public UnAcceptableProfile(string message) {
            _message = message;
        }
        override public string ToString() {
            return $"不支持此类型截面 或 不支持此类型截面的当前参数：\n{_message}";
        }
    }
    /// <summary>
    /// 匹配模式集合
    /// </summary>
    public static class PatternCollection {
        /// <summary>
        /// 前置标识符为 H 或 HP 或 HW 或 HM 或 HN 或 HT 或 WH，后续参数形式为 h1[~h2]*b1[/b2]*s*t1[/t2]。
        /// </summary>
        public static string H_1 => @"^((H[PWMNT]?)|WH)(?<h1>\d+\.?\d*)(~(?<h2>\d+\.?\d*))?"
                                    + @"\*(?<b1>\d+\.?\d*)(/(?<b2>\d+\.?\d*))?"
                                    + @"\*(?<s>\d+\.?\d*)\*(?<t1>\d+\.?\d*)(/(?<t2>\d+\.?\d*))?$";
        /// <summary>
        /// 前置标识符为 HI 或 PHI 或 WI，后续参数形式为 h1[-h2]-s-t1*b1[-t2*b2]。
        /// </summary>
        public static string H_2 => @"^((P?H)|W)I(?<h1>\d+\.?\d*)(-(?<h2>\d+\.?\d*))?-(?<s>\d+\.?\d*)"
                                    + @"-(?<t1>\d+\.?\d*)\*(?<b1>\d+\.?\d*)(-(?<t2>\d+\.?\d*)\*(?<b2>\d+\.?\d*))?$";
        /// <summary>
        /// 前置标识符为 H 或 HW 或 HM 或 HN 或 HT，用"TYPE"分组接收，后续参数形式为 H*B，仅支持整数。
        /// </summary>
        public static string H_3 => @"^(?<TYPE>H([WMN]?|T))(?<H>\d+)\*(?<B>\d+)$";
        /// <summary>
        /// 前置标识符为 B_WLD_K，后续参数形式为 h1*h2*b1*s*t1。
        /// </summary>
        public static string H_4 => @"^B_WLD_K(?<h1>\d+\.?\d*)\*(?<h2>\d+\.?\d*)\*(?<b1>\d+\.?\d*)\*(?<s>\d+\.?\d*)\*(?<t1>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 B_WLD_A，后续参数形式为 h1*b1*s*t1。
        /// </summary>
        public static string H_5 => @"^B_WLD_A(?<h1>\d+\.?\d*)\*(?<b1>\d+\.?\d*)\*(?<s>\d+\.?\d*)\*(?<t1>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 B_WLD_H，后续参数形式为 h1*b1*b2*s*t1*t2。
        /// </summary>
        public static string H_6 => @"^B_WLD_H(?<h1>\d+\.?\d*)\*(?<b1>\d+\.?\d*)\*(?<b2>\d+\.?\d*)\*(?<s>\d+\.?\d*)\*(?<t1>\d+\.?\d*)\*(?<t2>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 I_VAR_A，后续参数形式为 h1-h2*b1-b2*s*t1。
        /// </summary>
        public static string H_7 => @"^I_VAR_A(?<h1>\d+\.?\d*)-(?<h2>\d+\.?\d*)\*(?<b1>\d+\.?\d*)-(?<b2>\d+\.?\d*)\*(?<s>\d+\.?\d*)\*(?<t1>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 PL，后续参数形式为 t*b*l。
        /// </summary>
        public static string PL_1 => @"\APL(?<t>\d+\.?\d*)(\*(?<b>\d+\.?\d*))?(\*(?<l>\d+\.?\d*))?\Z";
        /// <summary>
        /// 前置标识符为 φ 或 D 或 ELD 或 ROD，后续参数形式为 d1。
        /// </summary>
        public static string CIRC_1 => @"^(φ|D|(ELD)|(ROD))(?<d1>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 PIP 或 CFCHS 或 CHS 或 EPD 或 O 或 PD 或 TUBE，后续参数形式为 d1*t。
        /// </summary>
        public static string CIRC_2 => @"^((PIP)|(CFCHS)|(CHS)|(EPD)|(O)|(PD)|(TUBE))(?<d1>\d+\.?\d*)\*(?<t>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 CFCHS 或 CHS 或 EPD 或 O 或 PD 或 TUBE，后续参数形式为 d1*d2*t。
        /// </summary>
        public static string CIRC_3 => @"^((CFCHS)|(CHS)|(EPD)|O|(PD)|(TUBE))(?<d1>\d+\.?\d*)\*(?<d2>\d+\.?\d*)\*(?<t>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 D 或 ELD 或 ROD，后续参数形式为 d1*r1*d2*r2。
        /// </summary>
        public static string CIRC_4 => @"^((EL)|(RO))?D(?<d1>\d+\.?\d*)\*(?<r1>\d+\.?\d*)\*(?<d2>\d+\.?\d*)\*(?<r2>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 CFCHS 或 CHS 或 EPD 或 O 或 PD 或 TUBE，后续参数形式为 d1*r1*d2*r2*t。
        /// </summary>
        public static string CIRC_5 => @"^((CFCHS)|(CHS)|(EPD)|O|(PD)|(TUBE))(?<d1>\d+\.?\d*)\*(?<r1>\d+\.?\d*)"
                                        + @"\*(?<d2>\d+\.?\d*)\*(?<r2>\d+\.?\d*)\*(?<t>\d+\.?\d*)$";
    }
    /// <summary>
    /// 型材截面基类
    /// </summary>
    public class ProfileBase {
        protected virtual void SetFieldsValues() { }
    }
    /// <summary>
    /// H型钢（通用形式）。适用如下形式：
    /// <para><see cref="PatternCollection.H_1"/></para>
    /// <para><see cref="PatternCollection.H_2"/></para>
    /// <para><see cref="PatternCollection.H_4"/></para>
    /// <para><see cref="PatternCollection.H_5"/></para>
    /// <para><see cref="PatternCollection.H_6"/></para>
    /// <para><see cref="PatternCollection.H_7"/></para>
    /// </summary>
    public class ProfileH : ProfileBase {
        private string _profileText;
        public double h1;
        public double h2;
        public double b1;
        public double b2;
        public double s;
        public double t1;
        public double t2;
        public string ProfileText {
            get => _profileText;
            set {
                _profileText = value;
                SetFieldsValues();
            }
        }
        public ProfileH() { }
        public ProfileH(string profileText) {
            ProfileText = profileText;
        }
        protected override void SetFieldsValues() {
            h1 = h2 = b1 = b2 = s = t1 = t2 = 0;
            try {
                if (string.IsNullOrEmpty(ProfileText))
                    throw new UnAcceptableProfile(ProfileText);

                Match match = Regex.Match(ProfileText, PatternCollection.H_1);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_2);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_4);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_5);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_6);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_7);
                if (!match.Success)
                    throw new UnAcceptableProfile(ProfileText);

                double.TryParse(match.Groups["h1"].Value, out h1);
                double.TryParse(match.Groups["h2"].Value, out h2);
                double.TryParse(match.Groups["b1"].Value, out b1);
                double.TryParse(match.Groups["b2"].Value, out b2);
                double.TryParse(match.Groups["s"].Value, out s);
                double.TryParse(match.Groups["t1"].Value, out t1);
                double.TryParse(match.Groups["t2"].Value, out t2);

                if (h2 == 0) h2 = h1;
                if (b2 == 0) b2 = b1;
                if (t2 == 0) t2 = t1;
            } catch (UnAcceptableProfile) {
                h1 = h2 = b1 = b2 = s = t1 = t2 = 0;
                throw;
            }
        }
    }
    /// <summary>
    /// 等截面H型钢和对称变截面H型钢（b2 == b1 的情形）。适用如下形式：
    /// <para><see cref="PatternCollection.H_1"/></para>
    /// <para><see cref="PatternCollection.H_2"/></para>
    /// <para><see cref="PatternCollection.H_4"/></para>
    /// <para><see cref="PatternCollection.H_5"/></para>
    /// <para><see cref="PatternCollection.H_6"/></para>
    /// <para><see cref="PatternCollection.H_7"/></para>
    /// </summary>
    public class ProfileH_Symmetrical : ProfileBase {
        private string _profileText;
        public double h1;
        public double h2;
        public double b1;
        public double b2;
        public double s;
        public double t1;
        public double t2;
        public string ProfileText {
            get => _profileText;
            set {
                _profileText = value;
                SetFieldsValues();
            }
        }
        public ProfileH_Symmetrical() { }
        public ProfileH_Symmetrical(string profileText) {
            ProfileText = profileText;
        }
        protected override void SetFieldsValues() {
            h1 = h2 = b1 = b2 = s = t1 = t2 = 0;
            try {
                if (string.IsNullOrEmpty(ProfileText))
                    throw new UnAcceptableProfile(ProfileText);

                Match match = Regex.Match(ProfileText, PatternCollection.H_1);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_2);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_4);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_5);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_6);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.H_7);
                if (!match.Success)
                    throw new UnAcceptableProfile(ProfileText);

                double.TryParse(match.Groups["h1"].Value, out h1);
                double.TryParse(match.Groups["h2"].Value, out h2);
                double.TryParse(match.Groups["b1"].Value, out b1);
                double.TryParse(match.Groups["b2"].Value, out b2);
                double.TryParse(match.Groups["s"].Value, out s);
                double.TryParse(match.Groups["t1"].Value, out t1);
                double.TryParse(match.Groups["t2"].Value, out t2);

                if (h2 == 0) h2 = h1;
                if (b2 == 0) b2 = b1;
                if (t2 == 0) t2 = t1;

                if (!ProfileText.Contains("I_VAR_A") && h2 != h1 || b2 != b1)
                    throw new UnAcceptableProfile(ProfileText);
            } catch (UnAcceptableProfile) {
                h1 = h2 = b1 = b2 = s = t1 = t2 = 0;
                throw;
            }
        }
    }
    /// <summary>
    /// 板。适用如下形式：
    /// <para><see cref="PatternCollection.PL_1"/></para>
    /// </summary>
    public class ProfilePlate : ProfileBase {
        private string _profileText;
        public double t;
        public double b;
        public double l;
        public string ProfileText {
            get => _profileText;
            set {
                _profileText = value;
                SetFieldsValues();
            }
        }
        public ProfilePlate() { }
        public ProfilePlate(string profileText) {
            ProfileText = profileText;
        }
        protected override void SetFieldsValues() {
            t = b = l = 0;
            if (ProfileText == null || ProfileText == string.Empty)
                throw new UnAcceptableProfile(ProfileText);

            Match match = Regex.Match(ProfileText, PatternCollection.PL_1);
            if (!match.Success)
                throw new UnAcceptableProfile(ProfileText);

            double.TryParse(match.Groups["t"].Value, out t);
            double.TryParse(match.Groups["b"].Value, out b);
            double.TryParse(match.Groups["l"].Value, out l);
        }
    }
    /// <summary>
    /// 圆钢或圆管（通用形式，含椭圆）。适用如下形式：
    /// <para><see cref="PatternCollection.CIRC_1"/></para>
    /// <para><see cref="PatternCollection.CIRC_2"/></para>
    /// <para><see cref="PatternCollection.CIRC_3"/></para>
    /// <para><see cref="PatternCollection.CIRC_4"/></para>
    /// <para><see cref="PatternCollection.CIRC_5"/></para>
    /// </summary>
    public class ProfileCircular : ProfileBase {
        private string _profileText;
        public double d1;
        public double r1;
        public double d2;
        public double r2;
        public double t;

        public string ProfileText {
            get => _profileText;
            set {
                _profileText = value;
                SetFieldsValues();
            }
        }
        public ProfileCircular() { }
        public ProfileCircular(string profileText) {
            ProfileText = profileText;
        }
        protected override void SetFieldsValues() {
            d1 = r1 = d2 = r2 = t = 0;
            try {
                if (string.IsNullOrEmpty(ProfileText))
                    throw new UnAcceptableProfile(ProfileText);

                Match match = Regex.Match(ProfileText, PatternCollection.CIRC_1);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_2);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_3);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_4);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_5);
                if (!match.Success)
                    throw new UnAcceptableProfile(ProfileText);

                double.TryParse(match.Groups["d1"].Value, out d1);
                double.TryParse(match.Groups["r1"].Value, out r1);
                double.TryParse(match.Groups["d2"].Value, out d2);
                double.TryParse(match.Groups["r2"].Value, out r2);
                double.TryParse(match.Groups["t"].Value, out t);

                if (r1 == 0) r1 = d1;
                if (d2 == 0) d2 = d1;
                if (r2 == 0) r2 = r1;
            } catch (UnAcceptableProfile) {
                d1 = r1 = d2 = r2 = t = 0;
                throw;
            }
        }
    }
    /// <summary>
    /// 圆钢或圆管（正圆形式，不含椭圆，含正圆变截面）。适用如下形式：
    /// <para><see cref="PatternCollection.CIRC_1"/></para>
    /// <para><see cref="PatternCollection.CIRC_2"/></para>
    /// <para><see cref="PatternCollection.CIRC_3"/></para>
    /// </summary>
    public class ProfileCircular_Perfect : ProfileBase {
        private string _profileText;
        public double d1;
        public double d2;
        public double t;

        public string ProfileText {
            get => _profileText;
            set {
                _profileText = value;
                SetFieldsValues();
            }
        }
        public ProfileCircular_Perfect() { }
        public ProfileCircular_Perfect(string profileText) {
            ProfileText = profileText;
        }
        protected override void SetFieldsValues() {
            d1 = d2 = t = 0;
            try {
                if (string.IsNullOrEmpty(ProfileText))
                    throw new UnAcceptableProfile(ProfileText);

                Match match = Regex.Match(ProfileText, PatternCollection.CIRC_1);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_2);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CIRC_3);
                if (!match.Success)
                    throw new UnAcceptableProfile(ProfileText);

                double.TryParse(match.Groups["d1"].Value, out d1);
                double.TryParse(match.Groups["d2"].Value, out d2);
                double.TryParse(match.Groups["t"].Value, out t);

                if (d2 == 0) d2 = d1;
            } catch (UnAcceptableProfile) {
                d1 = d2 = t = 0;
                throw;
            }
        }
    }
    /// <summary>
    /// 通用操作
    /// </summary>
    public static class CommonOperation {
        /// <summary>
        /// 交换数据。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">要交换的数据</param>
        /// <param name="b">要交换的数据</param>
        public static void Swap<T>(ref T a, ref T b) {
            T t;
            t = a;
            a = b;
            b = t;
        }
        /// <summary>
        /// 极值枚举
        /// </summary>
        public enum ExtremeTypeEnum {
            /// <summary>
            /// 局部极小值
            /// </summary>
            LocalMinimum,
            /// <summary>
            /// 局部极大值
            /// </summary>
            LocalMaximum,
        }
        /// <summary>
        /// 找出数据集合 <paramref name="data"/> 中的局部极值，并返回其序号集合。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">给定数据集合。</param>
        /// <param name="type">极值类型。</param>
        /// <param name="interval">用来判断极值的最小区间，应当为3以上的奇数，输入偶数则向上进1。</param>
        /// <returns>可能的局部极值的序号集合。入参为null或不符合规则，则返回null。</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static List<int> GetLocalExtremeIndexes<T>(
            IList<T> data,
            ExtremeTypeEnum type,
            int interval = 3)
            where T : IComparable<T> {

            if (data is null) {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.Count == 0)
                throw new ArgumentException($"“{nameof(data)}”中项目数应大于0。");

            if (interval < 3) interval = 3;
            if (interval % 2 == 0) interval++;

            var resault = new List<int>();
            var midIndex = interval / 2;

            if (data.Count == 1) {
                resault.Add(0);
                return resault;
            }

            //          ...
            //       +      -
            //     +         -
            //    =           =
            //  ??             ??
            //  扩展变化值中与端部紧邻的值以端部为中心对称取反；若相等则扩大一位取反；
            //  其余扩展变化值均等于此侧与端部紧邻的值
            //  示例中两端分别为 --, ++
            var variations = new List<int>(new int[data.Count + interval - 2]);
            for (int i = 0; i < data.Count - 1; i++) {
                variations[i + midIndex] = data[i + 1].CompareTo(data[i]);
            }
            if (variations[midIndex] == 0) {
                variations[midIndex - 1] = -1 * variations[midIndex + 1];
            } else {
                variations[midIndex - 1] = -1 * variations[midIndex];
            }
            if (variations[data.Count + midIndex - 2] == 0) {
                variations[data.Count + midIndex - 1] = -1 * variations[data.Count + midIndex - 3];
            } else {
                variations[data.Count + midIndex - 1] = -1 * variations[data.Count + midIndex - 2];
            }
            for (int i = 0; i < midIndex - 1; i++) {
                variations[midIndex - 2 - i] = variations[midIndex - 1 - i];
                variations[data.Count + midIndex + i] = variations[data.Count + midIndex - 1 + i];
            }


            var subVariations = new List<int>(new int[interval - 1]);
            for (int i = 0; i < data.Count; i++) {
                for (int j = 0; j < interval - 1; j++) {
                    subVariations[j] = variations[i + j];
                }

                if (MaybeExtreme(subVariations, type)) {
                    resault.Add(i);
                    i += midIndex;//  成功找到极值点跳转到当前局部区间右侧下一个值
                }
            }

            return resault;
        }
        /// <summary>
        /// 判断变化集合 <paramref name="variations"/> 是否符合极值分布。
        /// <para>
        ///     是 <see cref="GetLocalExtremeIndexes{T}(IList{T}, ExtremeTypeEnum, int)"/> 的配套方法。
        ///     <paramref name="variations"/> 元素数量必定为大于等于2的偶数。
        /// </para>
        /// </summary>
        /// <param name="variations">给定数据集合。</param>
        /// <param name="type">极值类型。</param>
        /// <returns>是否符合极值类型 <paramref name="type"/> 。</returns>
        /// <exception cref="ArgumentNullException"></exception>

        //                                            +         
        //                          +               +   -       
        //                        +   -           +       -     
        //              =       +       -       +               
        //            +   -   +           -   +                 
        //          +       -               =                   
        //        +                                             
        private static bool MaybeExtreme(List<int> variations, ExtremeTypeEnum type) {
            if (variations is null) {
                throw new ArgumentNullException(nameof(variations));
            }

            int cnt = variations.Count;
            int half = cnt / 2;

            //  左右只能有一个值相等
            if (variations[half - 1] == 0 && variations[half] == 0) return false;

            switch (type) {
            case ExtremeTypeEnum.LocalMinimum:
                for (int i = 0; i < half; i++) {
                    //  左边不允许正值,右边不允许负值
                    if (variations[i] > 0 || variations[cnt - 1 - i] < 0) return false;
                    //  只能中间两个值有一个值相等，其余值不允许相等
                    if ((variations[i] == 0 || variations[cnt - 1 - i] == 0) && i != half - 1) return false;
                }
                break;
            case ExtremeTypeEnum.LocalMaximum:
                for (int i = 0; i < half; i++) {
                    //  左边不允许负值,右边不允许正值
                    if (variations[i] < 0 || variations[cnt - 1 - i] > 0) return false;
                    //  只能中间两个值有一个值相等，其余值不允许相等
                    if ((variations[i] == 0 || variations[cnt - 1 - i] == 0) && i != half - 1) return false;
                }
                break;
            default:

                break;
            }

            return true;
        }
    }
}