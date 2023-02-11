import { Api } from "./api.js";
import { User } from "./user.js";
console.log('e')
var api= new Api();

var kor=JSON.parse(sessionStorage.getItem("logKorisnik"))

document.getElementById("createDiary").onclick= async (ev)=>{
    var name= document.getElementById("yourName").value
    var pass=document.getElementById("diarypass").value
    var dn={
        "name": name,
        "user": kor.id,
        "password": pass,
        "pages": [
        ]
      }
    var ch= await api.dodajDnevnik(dn)
    if(ch!=false){
        kor.diary=ch.id;
        var up=await api.updateKorisnik(kor);
        if(up!=false)
        {
            sessionStorage.setItem("logKorisnik",JSON.stringify(kor))
            window.location.href="home-page.html"
        }
        
    }
}