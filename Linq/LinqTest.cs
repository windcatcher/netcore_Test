using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq;

namespace Linq
{
    /*
    from[type] id in source
    [join[type] id in source on expr equals expr[into subGroup]]
    [from[type] id in source | let id = expr | where condition]
    [orderby ordering, ordering, ordering...]
    select expr | group expr by key
    [into id query] */
    public class LinqTest
    {

        //选择结果
        public void TestSelect()
        {
            var arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var newArr = (from item in arr where item > 3 && item < 7 select item);
            Console.WriteLine("大于3的项");
            newArr.ToList<int>().ForEach(p => { Console.WriteLine(p); });
            Console.ReadKey();
        }

        //选择结果 SelectNew  orderby 单位按面积排升序
        public static void TestSelectNew()
        {
            var lstUnit = BuildFactory.CreatUnits();
            var lstNewUnit = from unit in lstUnit
                             select new { unit.Name, unit.Area } into newUnits
                             orderby newUnits.Area ascending
                             select newUnits;
            foreach (var item in lstNewUnit)
                Console.WriteLine(string.Format("单位名称：{0}，商业面积：{1}", item.Name, item.Area));
            Console.ReadKey();
        }

        //MethodWhere
        public static void TestMethodWhere()
        {
            var arr = new List<int> { 1, 9, 3, 8, 5, 2, 7, 4, 2 };
            var result = arr.Where<int>((p) => { return p > 3; }) as List<int>;
            Console.WriteLine("大于3的项");
            result.ForEach(p => { Console.WriteLine(p); });
        }

        //LinqWhere
        public static void TestLinqWhere()
        {
            var arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var newArr = (from item in arr where item > 3 && item < 7 select item);
            Console.WriteLine("大于3的项");
            newArr.ToList<int>().ForEach(p => { Console.WriteLine(p); });
            Console.ReadKey();
        }

        //group 利用分组计算建筑所属单位的商业总面积
        public static void TestLinqGroup()
        {
            Console.WriteLine("------利用分组计算建筑所属单位的商业总面积------");
            var buildLst = BuildFactory.CreatBuilds();
            var unitlst = BuildFactory.CreatUnits();
            var BuildUnits = from unit in unitlst
                             join build in buildLst on unit.BuildId equals build.BuildId
                             select new { unit.Area, unit.BuildId, build.Name } into newBuildUnits
                             group newBuildUnits by newBuildUnits.BuildId into g
                             select new { BuildName = g.Select(p => p.Name).First(), TotalArea = g.Sum(p => p.Area) };
            foreach (var item in BuildUnits)
                Console.WriteLine(string.Format("建筑名称：{0}，商业总面积：{1}", item.BuildName, item.TotalArea));
            Console.ReadKey();
        }
        //max

        //join  查询国贸大厦C座，商业面积大于200平米的商铺
        public static void TestLinqJoin()
        {
            Console.WriteLine("------查询国贸大厦C座，商业面积大于200平米的商铺------");
            var buildLst = BuildFactory.CreatBuilds();
            var unitlst = BuildFactory.CreatUnits();
            var BuildUnits = from unit in unitlst
                             join build in buildLst
                             on unit.BuildId equals build.BuildId
                             where build.Name == "国贸大厦C座"
                             select new
                             {
                                 BuildName = build.Name,
                                 BuildHeight = build.Height,
                                 UnitName = unit.Name,
                                 UnitArea = unit.Area,
                                 UnitFloorIndex = unit.FloorIndex
                             } into newBuildUnits
                             where newBuildUnits.UnitArea > 200
                             select newBuildUnits;
            foreach (var item in BuildUnits)
                Console.WriteLine(string.Format("单位名称：{0}，楼层：{1},商业面积:{2},建筑名称:{3},建筑高度:{4}",
                    item.UnitName, item.UnitFloorIndex, item.UnitArea, item.BuildName, item.BuildHeight));
            Console.ReadKey();
        }
    }

    public class BuildFactory
    {
        public static List<Build> CreatBuilds()
        {
            var buildLst = new List<Build>() {
                new Build(){Name="世贸大厦A座",BuildId="BuildId_001",Height=20},
                new Build(){Name="帝豪花园A栋",BuildId="BuildId_002",Height=36.9f},
                new Build(){Name="假日豪庭F栋",BuildId="BuildId_003",Height=10.8f},
                new Build(){Name="国贸大厦C座",BuildId="BuildId_004",Height=50.8f},
            };
            return buildLst;
        }

        public static List<Unit> CreatUnits()
        {
            var buildLst = new List<Unit>() {
                new Unit(){Name="中国银行",BuildId="BuildId_001",Area=70,UnitId="UnitId_001",FloorIndex=1},
                new Unit(){Name="链家地产",BuildId="BuildId_001",Area=90.7f,UnitId="UnitId_006",FloorIndex=1},
                new Unit(){Name="海底捞",BuildId="BuildId_002",Area=59,UnitId="UnitId_002",FloorIndex=10},
                new Unit(){Name="万达影院",BuildId="BuildId_003",Area=240.8f,UnitId="UnitId_003",FloorIndex=6},
                new Unit(){Name="优衣库",BuildId="BuildId_004",Area=180.8f,UnitId="UnitId_004",FloorIndex=8},
                 new Unit(){Name="麦乐迪",BuildId="BuildId_004",Area=200.8f,UnitId="UnitId_005",FloorIndex=7},
            };
            return buildLst;
        }
    }

    /// <summary>
    /// 建筑
    /// </summary>
    public class Build
    {
        public string Name { get; set; }
        public float Height { get; set; }

        public string BuildId { get; set; }
    }


    /// <summary>
    /// 建筑单元
    /// </summary>
    public class Unit
    {
        public string Name { get; set; }
        public float Area { get; set; }
        public string BuildId { get; set; }

        public string UnitId { get; set; }

        public int FloorIndex { get; set; }

        public override string ToString()
        {
            return string.Format("单位名称：{0}，商业面积：{1}，楼层：{2}", Name, Area, FloorIndex);
        }
    }
}
