import { Api } from "./api.js";

var api= new Api();

var kor=JSON.parse(sessionStorage.getItem("logKorisnik"))
var dn=await api.getDiaryById(kor.diary);
document.getElementsByName("nameandlast").forEach(el=>{
    el.innerHTML=kor.name+' '+kor.lastName
})
const dat=new Date().toLocaleDateString("es-CL");
      console.log(dat)

document.getElementById("create").onclick=async (ev)=>{
    var weather=document.getElementById("weather").value
    var feeling=document.getElementById("feeling").value
    var content=document.getElementById("content").value
    var page={
        "diary": dn.id,
        "feeling": feeling,
        "weather": weather,
        "pageContent": content,
        "datetime": dat
      }
    var ch= await api.dodajStranu(page)
    if(ch!=false){
        console.log(ch.id)
            dn.pages.push(ch.id)
            var up= await api.updateDnevnik(dn)
            if(up!=false){
                window.location.reload();
            }
    }
}