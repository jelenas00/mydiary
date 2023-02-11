import { Api } from "./api.js";

var api= new Api();

var kor=JSON.parse(sessionStorage.getItem("logKorisnik"))
var dn=await api.getDiaryById(kor.diary);
document.getElementsByName("nameandlast").forEach(el=>{
    el.innerHTML=kor.name+' '+kor.lastName
})
document.getElementById("fullName").value=kor.name
document.getElementById("lastName").value=kor.lastName
document.getElementById("username").value=kor.username
document.getElementById("email").value=kor.email
document.getElementById("diaryName").value=dn.name

document.getElementById("savech").onclick=async (ev)=>{
    var chm=0
    var chu=0
    var em=-1
    var us=-1
    var name=document.getElementById("fullName").value
    var last=document.getElementById("lastName").value
    var username=document.getElementById("username").value
    var email=document.getElementById("email").value
    var dairy=document.getElementById("diaryName").value
    kor.name=name
    kor.lastName=last
    if(kor.username!==username){
        console.log("Nismo isti")
        chu=1
        kor.username=username
    }
    if(kor.email!==email)
    {
        console.log("Nismo isti mail")
        chm=1
        kor.email=email
    }
    if(chm==1)
    {
        em=await api.updateKorisnikEmail(kor);
    }
    if(chu==1)
    {
        us= await api.updateKorisnikUsername(kor)
    }
    console.log(kor)
    if(em==true && us==true)
    {
        var ch= await api.updateKorisnik(kor);
        if(ch==false)
        {
            alert("Email i username uspesno izmenjeni, ali je doslo do greske, pokusajte kasnije opet...")
        }
        else{
            sessionStorage.setItem("logKorisnik",JSON.stringify(ch))
            location.reload()
        }
    }
    else{
        var ch= await api.updateKorisnik(kor);
        if(ch==false)
        {
            alert("Email i username uspesno izmenjeni, ali je doslo do greske, pokusajte kasnije opet...")
        }
        else{
            sessionStorage.setItem("logKorisnik",JSON.stringify(ch))
            location.reload()
        }
    }

}

document.getElementById("nameprikaz").innerText=kor.name
document.getElementById("lastnameprikaz").innerText=kor.lastName
document.getElementById("usernameprikaz").innerText=kor.username
document.getElementById("emailprikaz").innerText=kor.email
document.getElementById("diaryprikaz").innerText=dn.name


document.getElementById("chpass").onclick=async (ev)=>{
    var pass=document.getElementById("currentPassword").value
    var newpass=document.getElementById("newPassword").value
    var renewpass=document.getElementById("renewPassword").value
    if(String(pass).length==0)
    {
        alert("Unesite lozniku!")
    }
    else if(String(newpass).length==0)
    {
        alert("Unesite novu lozniku!")
    }
    else if(String(renewpass).length==0)
    {
        alert("Unesite ponovo novu lozniku!")
    }
    else if(newpass!==renewpass)
    {
        alert("Nove lozinke se ne poklapaju!")
    }
    else if(pass!==kor.password)
    {
        alert("Pogresna lozinka!")
    }
    else if(pass===newpass)
    {
        alert("Nova loznika ne moze biti ista kao stara!")
    }
    else{
        kor.password=newpass
        var ch= await api.updateKorisnik(kor);
        if(ch==false)
        {
            alert("Greska! Pokusajte ponovo kasnije!")
        }
        else{
            alert("Uspesno izmenjena lozinka!")
            sessionStorage.setItem("logKorisnik",JSON.stringify(ch))
            location.reload()
        }
    }
}

document.getElementById("deleteacc").onclick=async (ev)=>{
    let text = "Da li ste sigurni da zelite da obrisete nalog?";
    if (confirm(text) == true) {
        console.log("true")
        deleteacc()
    } else {
        console.log("false")
        document.getElementById("demo").style.display="none"
    }
    document.getElementById("demo").innerHTML = text;
}

async function deleteacc(){
    var ch= await api.deleteKorisnika(kor.id)
    if(ch==true){
        alert("Nalog uspesno obrisan!")
        sessionStorage.clear()
        window.location.href = "index.html";
    }
    else{
        alert("Doslo je do greske, pokusajte ponovo kasnije!")
    }
}
