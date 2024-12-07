using System;
using System.Text.RegularExpressions;

namespace Muggle.TeklaPlugins.Common.Profile {
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
        /// <summary>
        /// 前置标识符为 F 或 J 或 P 或 TUB 或 RHS 或 SHS 或 CFRHS，后续参数形式为 h1*s。
        /// </summary>
        public static string CFH_J_1 => @"^(F|J|P|(TUB)|(RHS)|(SHS)|(CFRHS))(?<h1>\d+\.?\d*)\*(?<s>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 F 或 J 或 P 或 RHS 或 SHS 或 CFRHS，后续参数形式为 h1*b1*s。
        /// </summary>
        public static string CFH_J_2 => @"^(F|J|P|(RHS)|(SHS)|(CFRHS))(?<h1>\d+\.?\d*)\*(?<b1>\d+\.?\d*)\*(?<s>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 P 或 RHS 或 SHS 或 CFRHS，后续参数形式为 h1*b1-h2*b2*s。
        /// </summary>
        public static string CFH_J_3 => @"^(P|(RHS)|(SHS)|(CFRHS))(?<h1>\d+\.?\d*)\*(?<b1>\d+\.?\d*)-(?<h2>\d+\.?\d*)\*(?<b2>\d+\.?\d*)\*(?<s>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 B_WLD_F，后续参数形式为 h1*b1*s。
        /// </summary>
        public static string RECT_1 => @"^B_WLD_F(?<h1>\d+\.?\d*)\*(?<b1>\d+\.?\d*)\*(?<s>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 RECT 或 B_WLD_F 或 B_BUILT，后续参数形式为 h1*b1*s*t。
        /// </summary>
        public static string RECT_2 => @"^((RECT)|(B_WLD_F)|(B_BUILT))(?<h1>\d+\.?\d*)\*(?<b1>\d+\.?\d*)\*(?<s>\d+\.?\d*)\*(?<t>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 R，后续参数形式为 h1~h2*b1*s*t。
        /// </summary>
        public static string RECT_3 => @"^R(?<h1>\d+\.?\d*)~(?<h2>\d+\.?\d*)\*(?<b1>\d+\.?\d*)\*(?<s>\d+\.?\d*)\*(?<t>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 B_WLD_J，后续参数形式为 h1*h2*b1*s*t。
        /// </summary>
        public static string RECT_4 => @"^B_WLD_J(?<h1>\d+\.?\d*)\*(?<h2>\d+\.?\d*)\*(?<b1>\d+\.?\d*)\*(?<s>\d+\.?\d*)\*(?<t>\d+\.?\d*)$";
        /// <summary>
        /// 前置标识符为 B_VAR_A 或 B_VAR_B 或 B_VAR_C，后续参数形式为 h1-h2*s[*b1[-b2]]。b1, b2 值均忽略。
        /// </summary>
        public static string RECT_5 => @"^B_VAR_[ABC](?<h1>\d+\.?\d*)-(?<h2>\d+\.?\d*)\*(?<s>\d+\.?\d*)\*(\d+\.?\d*)-(\d+\.?\d*)$";
    }
    public interface IProfile {
        /// <summary>
        /// 截面文本
        /// </summary>
        string ProfileText { get; set; }
    }
    /// <summary>
    /// 型材截面基类
    /// </summary>
    public class ProfileBase {

        protected virtual void SetFieldsValues() { }
    }
    /// <summary>
    /// H型钢（通用形式）。适用如下形式：<para></para>
    /// <see cref="PatternCollection.H_1"/>：<inheritdoc cref="PatternCollection.H_1"/><para></para>
    /// <see cref="PatternCollection.H_2"/>：<inheritdoc cref="PatternCollection.H_2"/><para></para>
    /// <see cref="PatternCollection.H_4"/>：<inheritdoc cref="PatternCollection.H_4"/><para></para>
    /// <see cref="PatternCollection.H_5"/>：<inheritdoc cref="PatternCollection.H_5"/><para></para>
    /// <see cref="PatternCollection.H_6"/>：<inheritdoc cref="PatternCollection.H_6"/><para></para>
    /// <see cref="PatternCollection.H_7"/>：<inheritdoc cref="PatternCollection.H_7"/><para></para>
    /// </summary>
    public class ProfileH : ProfileBase, IProfile {
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
    /// 等截面H型钢和对称变截面H型钢（b2 == b1 的情形）。适用如下形式：<para></para>
    /// <see cref="PatternCollection.H_1"/>：<inheritdoc cref="PatternCollection.H_1"/><para></para>
    /// <see cref="PatternCollection.H_2"/>：<inheritdoc cref="PatternCollection.H_2"/><para></para>
    /// <see cref="PatternCollection.H_4"/>：<inheritdoc cref="PatternCollection.H_4"/><para></para>
    /// <see cref="PatternCollection.H_5"/>：<inheritdoc cref="PatternCollection.H_5"/><para></para>
    /// <see cref="PatternCollection.H_6"/>：<inheritdoc cref="PatternCollection.H_6"/><para></para>
    /// <see cref="PatternCollection.H_7"/>：<inheritdoc cref="PatternCollection.H_7"/><para></para>
    /// </summary>
    public class ProfileH_Symmetrical : ProfileBase, IProfile {
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
    /// 板。适用如下形式：<para></para>
    /// <see cref="PatternCollection.PL_1"/>：<inheritdoc cref="PatternCollection.PL_1"/><para></para>
    /// </summary>
    public class ProfilePlate : ProfileBase, IProfile {
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
    /// 圆钢或圆管（通用形式，含椭圆）。适用如下形式：<para></para>
    /// <see cref="PatternCollection.CIRC_1"/>：<inheritdoc cref="PatternCollection.CIRC_1"/><para></para>
    /// <see cref="PatternCollection.CIRC_2"/>：<inheritdoc cref="PatternCollection.CIRC_2"/><para></para>
    /// <see cref="PatternCollection.CIRC_3"/>：<inheritdoc cref="PatternCollection.CIRC_3"/><para></para>
    /// <see cref="PatternCollection.CIRC_4"/>：<inheritdoc cref="PatternCollection.CIRC_4"/><para></para>
    /// <see cref="PatternCollection.CIRC_5"/>：<inheritdoc cref="PatternCollection.CIRC_5"/><para></para>
    /// </summary>
    public class ProfileCircular : ProfileBase, IProfile {
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
    /// 圆钢或圆管（正圆形式，不含椭圆，含正圆变截面）。适用如下形式：<para></para>
    /// <see cref="PatternCollection.CIRC_1"/>：<inheritdoc cref="PatternCollection.CIRC_1"/><para></para>
    /// <see cref="PatternCollection.CIRC_2"/>：<inheritdoc cref="PatternCollection.CIRC_2"/><para></para>
    /// <see cref="PatternCollection.CIRC_3"/>：<inheritdoc cref="PatternCollection.CIRC_3"/><para></para>
    /// </summary>
    public class ProfileCircular_Perfect : ProfileBase, IProfile {
        private string _profileText;
        public double d1;
        public double d2;
        public double t;
        private static readonly ProfileCircular_Perfect[] _commonlyUsed = new ProfileCircular_Perfect[] {
            new ProfileCircular_Perfect{ ProfileText = "PIP32*2.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP32*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP32*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP32*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP38*2.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP38*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP38*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP38*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP42*2.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP42*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP42*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP42*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP45*2.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP45*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP45*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP45*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*2.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP50*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP54*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP57*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP60*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP63.5*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP68*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP70*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP73*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*3"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP76*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP83*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP89*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP95*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*3.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP102*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP108*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP114*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP121*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP127*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*4"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP133*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP140*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP146*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP152*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP159*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*4.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP168*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP180*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*5.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP194*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP203*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*6"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP219*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP245*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*6.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*7"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP273*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP299*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*7.5"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP325*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*8"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP351*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP377*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP402*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP426*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP450*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP465*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP480*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP500*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP530*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP550*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP560*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP600*16"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*9"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*10"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*11"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*12"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*13"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*14"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*15"},
            new ProfileCircular_Perfect{ ProfileText = "PIP630*16"},
        };

        public string ProfileText {
            get => _profileText;
            set {
                _profileText = value;
                SetFieldsValues();
            }
        }
        /// <summary>
        /// 常用规格
        /// </summary>
        public static ProfileCircular_Perfect[] CommonlyUsed => _commonlyUsed;
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
    /// 矩形管（通用形式，含冷弯矩形管和焊接矩形管）。适用如下形式：<para></para>
    /// <see cref="PatternCollection.CFH_J_1"/>：<inheritdoc cref="PatternCollection.CFH_J_1"/><para></para>
    /// <see cref="PatternCollection.CFH_J_2"/>：<inheritdoc cref="PatternCollection.CFH_J_2"/><para></para>
    /// <see cref="PatternCollection.CFH_J_3"/>：<inheritdoc cref="PatternCollection.CFH_J_3"/><para></para>
    /// <see cref="PatternCollection.RECT_1"/>：<inheritdoc cref="PatternCollection.RECT_1"/><para></para>
    /// <see cref="PatternCollection.RECT_2"/>：<inheritdoc cref="PatternCollection.RECT_2"/><para></para>
    /// <see cref="PatternCollection.RECT_3"/>：<inheritdoc cref="PatternCollection.RECT_3"/><para></para>
    /// <see cref="PatternCollection.RECT_4"/>：<inheritdoc cref="PatternCollection.RECT_4"/><para></para>
    /// <see cref="PatternCollection.RECT_5"/>：<inheritdoc cref="PatternCollection.RECT_5"/><para></para>
    /// </summary>
    public class ProfileRect : ProfileBase, IProfile {
        private string _profileText;
        public double h1, h2, b1, b2, s, t;

        public string ProfileText {
            get => _profileText;
            set {
                _profileText = value;
                SetFieldsValues();
            }
        }
        public ProfileRect() { }
        public ProfileRect(string profileText) {
            ProfileText = profileText;
        }

        protected override void SetFieldsValues() {
            h1 = h2 = b1 = b2 = s = t = 0;
            try {
                if (string.IsNullOrEmpty(ProfileText))
                    throw new UnAcceptableProfile(ProfileText);

                var match = Regex.Match(ProfileText, PatternCollection.CFH_J_1);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CFH_J_2);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.CFH_J_3);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.RECT_1);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.RECT_2);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.RECT_3);
                if (!match.Success)
                    match = Regex.Match(ProfileText, PatternCollection.RECT_4);
                if (match.Success) {
                    double.TryParse(match.Groups["b1"].Value, out b1);
                    double.TryParse(match.Groups["b2"].Value, out b2);
                } else if (!match.Success) {
                    match = Regex.Match(ProfileText, PatternCollection.RECT_5);
                }
                if (!match.Success)
                    throw new UnAcceptableProfile(ProfileText);

                double.TryParse(match.Groups["h1"].Value, out h1);
                double.TryParse(match.Groups["h2"].Value, out h2);
                double.TryParse(match.Groups["s"].Value, out s);
                double.TryParse(match.Groups["t"].Value, out t);

                if (h2 == 0) h2 = h1;
                if (b1 == 0) b1 = h1;
                if (b2 == 0) b2 = b1;
                if (t == 0) t = s;

            } catch (UnAcceptableProfile) {
                h1 = h2 = b1 = b2 = s = t = 0;
                throw;
            }
        }
    }
    /// <summary>
    /// 矩形管（等截面形式）。适用如下形式：<para></para>
    /// <see cref="PatternCollection.CFH_J_1"/>：<inheritdoc cref="PatternCollection.CFH_J_1"/><para></para>
    /// <see cref="PatternCollection.CFH_J_2"/>：<inheritdoc cref="PatternCollection.CFH_J_2"/><para></para>
    /// <see cref="PatternCollection.CFH_J_3"/>：<inheritdoc cref="PatternCollection.CFH_J_3"/><para></para>
    /// <see cref="PatternCollection.RECT_1"/>：<inheritdoc cref="PatternCollection.RECT_1"/><para></para>
    /// <see cref="PatternCollection.RECT_2"/>：<inheritdoc cref="PatternCollection.RECT_2"/><para></para>
    /// <see cref="PatternCollection.RECT_3"/>：<inheritdoc cref="PatternCollection.RECT_3"/><para></para>
    /// <see cref="PatternCollection.RECT_4"/>：<inheritdoc cref="PatternCollection.RECT_4"/><para></para>
    /// <see cref="PatternCollection.RECT_5"/>：<inheritdoc cref="PatternCollection.RECT_5"/><para></para>
    /// </summary>
    public class ProfileRect_Invariant : ProfileRect {
        public new string ProfileText {
            get { return base.ProfileText; }
            set {
                var temp = (h1, h2, b1, b2, s, t);
                base.ProfileText = value;
                if (h2 != h1 || b2 != b1) {
                    h1 = temp.h1;
                    h2 = temp.h2;
                    b1 = temp.b1;
                    b2 = temp.b2;
                    s = temp.s;
                    t = temp.t;

                    throw new UnAcceptableProfile(value);
                }
            }
        }
        public ProfileRect_Invariant() : base() { }
        public ProfileRect_Invariant(string profileText) : base(profileText) {
            if (h2 != h1 || b2 != b1)
                throw new UnAcceptableProfile(profileText);
        }
    }
}
