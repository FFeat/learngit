public class MainClass
{
	publlic void Main(){
		Console.WriteLine("第三十位是“）；
	}
	public int GetNum(int i)
	{
		if(i<=0)
		return 0;
		else if(i>0&&i<=2)
		return 1;
		else return GEtNum(i-1)+GetNum(i-2);
	}

}
public static void Main(){
	Console.WriteLine(GetNum(30));
	
}
public int GetNum(int num){
	if(num==1&&num==2){
	return 1;
	}
	else{
		return GetNum(num-1)+GetNum(num-2);
	}
}
}
委托可以把一个方法作为参数代入另一个方法中，委托可以理解为指向一个函数的引用
	事件是一种特殊的委托
	
	
	private 私有成员，只能在类的内部访问
	protected 保护成员，可以在类以及类的派生类中访问
	public：公共成员，完全公开，没有访问限制
	internal：只能在同一命名空间下访问
	
	重载： 是方法的名称相同，参数或者参数类型不同，进行多次重载以适应不同的需要
	重写：override 是对基类中的函数重写，
B/s结构中需要传递变量值
	除开Session，cookis application 
	还可以用this.Server.Transfer 
		queryString
		cache
		HttpContext item 属性
		文件
		数据库

		
		foreach（Control ctl in this.Controls)
		{
			if(ctl is TextBox)
			{
				TextBox tb=(TextBox) ctl;
				tb.Text=Empty();
			}
		}
		int[] array=new int[n];
	
		for(int i=0;i<array.Length;i++)
		{
			for(int j=0;j<array.Length;j++)
			{
				if(array[i]<array[j])
				{
					int temp=array[i];
					array[i]=array[j];
					array[i]=temp;
				}
			}
		}
		
		for(int i=0;j<num);i++)
		{
			if(i%2==1)
			{
				Sum+=1;
			}else{
			Sum=Sum-1;
			}
		}
		
	使用MVC加简单三层
	class可以被实例化，可以被接口和单继承其他类，
		是分配在堆上的
		结构struct 值类型，不能作为基类，但是可以实现接口，是分配在栈上的
		
		public void Test(int i)
		{
			Lock(this){
			if(i>10)
			{
				i--;
			}
			Test(i);
			}
		}
	不会发生思索。因为是INT是值类型，每次改变的都只是一个副本
	如果是引用类型，就死锁就会产生
	
	remoting  利用TCP/IP，二进制传送提高效率
	webService 可利用HTTP 穿透防火墙
	
	select top 10* from table where id not in(select top30 id from table)
	select top 10* from table where id>(select max(id)from (select top 30 id from table )as a)
	封装 继承 多态
	
	IEnumerable GetEnumerable
	
	GC 是垃圾收集器，自动进行内存管理
	System.gc()
	
	string s new string ("asg") 
	创建了两个对象，一个是asg 一个是asg的引用
	
	abstract class 抽象类，用于创建一个体现某些基本行为的类，并未该类声明方法，但不能在该类中实现该类
	serializable
	serializable
	serializable
	serializable
	serializable
	
	[
	{"ctrlName":"/ActionInfo/",
		"allUrl":   [{"actionUrl":"/ActionInfo/Index"},
					{"actionUrl":"/ActionInfo/Details"},
					{"actionUrl":"/ActionInfo/Add"},
					{"actionUrl":"/ActionInfo/Add"},
					{"actionUrl":"/ActionInfo/Edit"},
					{"actionUrl":"/ActionInfo/Edit"},
					{"actionUrl":"/ActionInfo/Delete"},
					{"actionUrl":"/ActionInfo/GetAllUrl"}]},
	{"ctrlName":"/Base/","allUrl":]},
	{"ctrlName":"/Home/",
		"allUrl":
					[{"actionUrl":"/Home/Index"},
					{"actionUrl":"/Home/GetNoteInfoById"},
					{"actionUrl":"/Home/GetAllBasicNote"},
					{"actionUrl":"/Home/GetAllWinformNote"},
					{"actionUrl":"/Home/GetAllWebformNote"},
					{"actionUrl":"/Home/GetAllAspmvcNote"}]},
	{"ctrlName":"/Login/",
		"allUrl":
					[{"actionUrl":"/Login/Index"}]},
	{"ctrlName":"/RoleInfo/",
		"allUrl":
					[{"actionUrl":"/RoleInfo/Index"},
					{"actionUrl":"/RoleInfo/Details"},
					{"actionUrl":"/RoleInfo/Add"},
					{"actionUrl":"/RoleInfo/Add"},
					{"actionUrl":"/RoleInfo/Edit"},
					{"actionUrl":"/RoleInfo/Edit"},
					{"actionUrl":"/RoleInfo/Delete"}]},
	{"ctrlName":"/UserInfo/","allUrl":[{"actionUrl":"/UserInfo/Index"},{"actionUrl":"/UserInfo/Add"},{"actionUrl":"/UserInfo/Add"},{"actionUrl":"/UserInfo/Edit"},{"actionUrl":"/UserInfo/Edit"},{"actionUrl":"/UserInfo/Delete"},{"actionUrl":"/UserInfo/SetRole"},{"actionUrl":"/UserInfo/ProcessSetRole"}]}]}
	{[{"ctrlName":"/ActionInfo/",
	"allUrl":
		[{"actionUrl":"/ActionInfo/Index"},
		{"actionUrl":"/ActionInfo/Details"},
		{"actionUrl":"/ActionInfo/Add"},
		{"actionUrl":"/ActionInfo/Edit"},
		{"actionUrl":"/ActionInfo/Delete"},
		{"actionUrl":"/ActionInfo/GetAllUrl"}]},
	{"ctrlName":"/Base/","allUrl":]},
	{"ctrlName":"/Home/","allUrl":
		[{"actionUrl":"/Home/Index"},{"actionUrl":"/Home/GetNoteInfoById"},{"actionUrl":"/Home/GetAllBasicNote"},{"actionUrl":"/Home/GetAllWinformNote"},{"actionUrl":"/Home/GetAllWebformNote"},{"actionUrl":"/Home/GetAllAspmvcNote"}]},{"ctrlName":"/Login/","allUrl":[{"actionUrl":"/Login/Index"}]},{"ctrlName":"/RoleInfo/","allUrl":[{"actionUrl":"/RoleInfo/Index"},{"actionUrl":"/RoleInfo/Details"},{"actionUrl":"/RoleInfo/Add"},{"actionUrl":"/RoleInfo/Edit"},{"actionUrl":"/RoleInfo/Delete"}]},{"ctrlName":"/UserInfo/","allUrl":[{"actionUrl":"/UserInfo/Index"},{"actionUrl":"/UserInfo/Add"},{"actionUrl":"/UserInfo/Edit"},{"actionUrl":"/UserInfo/Delete"},{"actionUrl":"/UserInfo/SetRole"},{"actionUrl":"/UserInfo/ProcessSetRole"}]}]}	
		hahahah
		
		
		
		    $(function () {
        //选项卡切换事件
        $(".tab .menus").on("mouseover", 'li', function () {
            $('.tab .menus li').each(function () {
                $('.tab .menus li').mouseover(function () {
                    $('.tab .menus li').removeClass('bg');
                    $(this).addClass('bg');
                    var index = $(this).index();
                    $('.tab .scroll').css('margin-top', -index * 800 + 'px');

                })
            })
        })

    })
		
		11111
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		