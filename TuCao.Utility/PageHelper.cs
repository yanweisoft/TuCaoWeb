using System;
using System.Text;

namespace TuCao.Utility
{
    public class PageHelper
    {
        #region 属性

        string _pageUrl = @"http://localhost:2226/Newsfeed/All?page={0}"; //链接地址
        /// <summary>
        /// 链接地址
        /// </summary>
        public string PageUrl
        {
            get { return _pageUrl; }
            set { this._pageUrl = value; }
        }
        string _hrefPageNum = @"<a href=""{0}"">{1}</a>"; //带url的页号
        /// <summary>
        /// 带url的页号
        /// </summary>
        public string HrefPageNum
        {
            get { return _hrefPageNum; }
            set { this._hrefPageNum = value; }
        }
        string _pageNum = @"<a class=""current"" href=""#"" >{0}</a>";     //当前页
        /// <summary>
        /// 当前页
        /// </summary>
        public string PageNum
        {
            get { return _pageNum; }
            set { this._pageNum = value; }
        }
        string _prevPage = @"<a class=""prev"" href=""{0}"">上一页<span></span></a>";    //上一页
        /// <summary>
        /// //上一页
        /// </summary>
        public string PrevPage
        {
            get { return _prevPage; }
            set { this._prevPage = value; }
        }
        string _nextPage = @"<a class=""next"" href=""{0}"">下一页<span></span></a>";    //下一页
        /// <summary>
        /// 下一页
        /// </summary>
        public string NextPage
        {
            get { return _nextPage; }
            set { this._nextPage = value; }
        }

        string _spaceSign = "...";    //隔页符号
        /// <summary>
        /// 隔页符号
        /// </summary>
        public string SpaceSign        
        {
            get { return _spaceSign; }
            set { this._spaceSign = value; }
        }

        #endregion

        /// <summary>
        /// 生成列表页码
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageNum">每页显示条数</param>
        /// <param name="totalNum">总记录条数</param>
        /// <returns>分页的列表串</returns>
        public string BuildPageNum(int currentPage, long totalNum,int pageNum,bool isPageControl=true)
        {
            int totalPage = (int)Math.Ceiling(Convert.ToDouble(totalNum.ToString()) / pageNum); //总页数
            if (isPageControl)
            {
                if (totalPage > 10)
                {   //最多10页
                    totalPage = 10;
                }
            }
            currentPage = currentPage < 1 ? 1 : currentPage;
            currentPage = currentPage > totalPage ? totalPage : currentPage;
            StringBuilder sb = new StringBuilder();
            if (totalPage<=1)
            {
                return sb.ToString();
            }
            if (currentPage>1)
            {   //显示上一页
                sb.AppendFormat(PrevPage, string.Format(PageUrl, currentPage - 1)); //上一页
            }
            #region 中间页面
            if (totalPage > 7)
            {   //总页码大于7
                if (currentPage <= 4)
                {   //当前页码是前4页
                    for (int i = 0; i < 6; i++)
                    {   //前6页显示页码
                        if (i + 1 == currentPage)
                        {   //当前页
                            sb.AppendFormat(PageNum, currentPage);
                        }
                        else
                        {   //带页码的超级链接
                            sb.AppendFormat(HrefPageNum, string.Format(PageUrl, i + 1), i + 1);
                        }
                    }
                    sb.Append(SpaceSign);   //隔页符
                    ////去掉最后一页注释掉了下面的一行,看是否符合要求再修改(路思勇)
                    //sb.AppendFormat(HrefPageNum, string.Format(PageUrl, totalPage), totalPage); //最后一页
                }
                else if (totalPage - currentPage < 5)
                {   //当前页码是末5页
                    sb.AppendFormat(HrefPageNum, string.Format(PageUrl, 1), 1); //第一页
                    sb.Append(SpaceSign);   //隔页符
                    for (int i = totalPage-6; i < totalPage; i++)
                    {
                        if (i + 1 == currentPage)
                        {   //当前页
                            sb.AppendFormat(PageNum, currentPage);
                        }
                        else
                        {   //带页码的超级链接
                            sb.AppendFormat(HrefPageNum, string.Format(PageUrl, i + 1), i + 1);
                        }
                    }
                }
                else
                {    //当前页码非前4页、末5页时，前后各保留两个页码，其余页码缩略显示
                    sb.AppendFormat(HrefPageNum, string.Format(PageUrl, 1), 1); //第一页
                    sb.Append(SpaceSign);   //隔页符
                    for (int i = currentPage-3; i < currentPage+2; i++)
                    {
                        if (i + 1 == currentPage)
                        {   //当前页
                            sb.AppendFormat(PageNum, currentPage);
                        }
                        else
                        {   //带页码的超级链接
                            sb.AppendFormat(HrefPageNum, string.Format(PageUrl, i + 1), i + 1);
                        }
                    }
                    sb.Append(SpaceSign);   //隔页符
                    ////去掉最后一页注释掉了下面的一行,看是否符合要求再修改(路思勇)
                    //sb.AppendFormat(HrefPageNum, string.Format(PageUrl, totalPage), totalPage); //最后一页
                }
            }
            else
            {   //总页码小于7，全部显示
                for (int i = 0; i < totalPage; i++)
                {
                    if (i+1==currentPage)
                    {   //当前页
                        sb.AppendFormat(PageNum, currentPage);
                    }
                    else
                    {   //带页码的超级链接
                        sb.AppendFormat(HrefPageNum, string.Format(PageUrl, i + 1), i + 1);
                    }
                }
            }
            #endregion
            if (currentPage!=totalPage)
            {   //显示下一页
                sb.AppendFormat(NextPage, string.Format(PageUrl, currentPage + 1)); //下一页
            }

            return sb.ToString();
        }
    }
}
