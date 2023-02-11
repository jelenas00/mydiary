import { Api } from "./api.js";
import { User } from "./user.js";

var api= new Api();

document.getElementById("register").onclick=async (ev)=>{
    var name=document.getElementById("yourName").value
    var lastName=document.getElementById("yourLastName").value
    var username=document.getElementById("yourUsername").value
    var email=document.getElementById("yourEmail").value
    var pass=document.getElementById("yourPassword").value
    var bday=document.getElementById("yourBday").value

    console.log(name,lastName,username,email,pass,bday)
    var kor={
        "name": name,
        "lastName": lastName,
        "email": email,
        "username": username,
        "password": pass,
        "diary": "",
        "birthday": bday
      }
    var ch= await api.dodajKorisnika(kor)
    if(ch!=false){
        var korLog= await api.prijavaKorisnika(email,pass)
        if(korLog!=false){
            sessionStorage.setItem("logKorisnik",JSON.stringify(ch))
            window.location.href="pages-diary.html";
        }
    }
}