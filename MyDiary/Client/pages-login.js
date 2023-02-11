import { Api } from "./api.js";
import { User } from "./user.js";

var api= new Api();

document.getElementById("login").onclick=async (ev)=>{
    var user=document.getElementById("yourUsername").value;
    var pass= document.getElementById("yourPassword").value;
    var ch= await api.prijavaKorisnika(user,pass);
    console.log(ch);
    if(ch==false){
        alert("Doslo je do greske!Provgerite email i lozinku!")
    }
    else{
        sessionStorage.setItem("logKorisnik",JSON.stringify(ch))
        window.location.href="home-page.html";
    }
}

