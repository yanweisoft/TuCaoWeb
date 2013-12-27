using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TuCao.Utility
{
    public class SimleHelper
    {
        public static string GetSimleImg(string content)
        {
            string imgUrl = @"http://x.autoimg.cn/club/smiles/{0}.gif";
            List<string> simleArr = new List<string> { "[微笑]", "[撇嘴]", "[色]", "[发呆]", "[得意]", "[流泪]", "[害羞]", "[闭嘴]", "[睡]", "[大哭]", "[尴尬]", "[发怒]", "[调皮]", "[嘻嘻]", "[惊讶]", "[难过]", "[酷]", "[冷汗]", "[抓狂]", "[吐]", "[偷笑]", "[可爱]", "[白眼]", "[傲慢]", "[饥饿]", "[困]", "[惊恐]", "[汗]", "[憨笑]", "[大兵]", "[奋斗]", "[咒骂]", "[疑问]", "[嘘]", "[晕]", "[折磨]", "[衰]", "[骷髅]", "[敲打]", "[再见]", "[擦汗]", "[挖鼻]", "[鼓掌]", "[糗大了]", "[坏笑]", "[左哼哼]", "[右哼哼]", "[哈欠]", "[鄙视]", "[委屈]", "[快哭了]", "[阴险]", "[亲亲]", "[吓]", "[可怜]", "[菜刀]", "[西瓜]", "[啤酒]", "[篮球]", "[乒乓]", "[咖啡]", "[饭]", "[猪头]", "[玫瑰]", "[凋零]", "[示爱]", "[爱心]", "[心碎]", "[蛋糕]", "[闪电]", "[炸弹]", "[刀]", "[足球]", "[瓢虫]", "[便便]", "[月亮]", "[太阳]", "[礼物]", "[拥抱]", "[强]", "[弱]", "[握手]", "[胜利]", "[抱拳]", "[勾引]", "[拳头]", "[差劲]", "[爱你]", "[NO]", "[OK]" };
            var match = Regex.Matches(content, @"(?:\[|［|【)\s*(?:.{1,4}?)\s*(?:\]|］|】)", RegexOptions.IgnoreCase);
            if (match != null && match.Count > 0)
            {
                foreach (Match m in match)
                {
                    string clearUBB = m.Value.Replace("［", "[").Replace("］", "]").Replace("【", "[").Replace("】", "]").Replace(" ", "").Replace("　", "").ToUpper();
                    int simleIndex = simleArr.IndexOf(clearUBB);
                    if (simleIndex >= 0)
                    {
                        content = content.Replace(m.ToString(), "<span class='face_img'><img src='" + string.Format(imgUrl, simleIndex) + "'/></span>");
                    }

                }
            }
            return content;
        }
    }
}
