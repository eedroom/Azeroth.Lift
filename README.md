# Azeroth.Lift
asp.net mvc+autofac+castle+ef+bootsrap+easyui的项目模板


class A{
 public string Name{set;get;}
 public int Age{set;get;}
}

class B{
  [newtong.json.jsonpropert(propertyName="Name")]
 public string NikeName{set;get;}

}

var jsonstr=newton.json.jsonconvert.seriliaze(new A{Name="111",Age=3});

var bobj=newton.json.jsonconvert.deseirliaze<B>(jsonstr);
