import { User } from "./user.js";
import { Page } from "./page.js";
import { Diary } from "./diary.js";

export class Api{
    constructor(){}

    //////////////POST
    async dodajKorisnika(korisnik){

        let response = await fetch("http://localhost:5022/Users/CreateUser",
        {
            headers:
            {
                Accept:"application/json",
                "Content-type":"application/json",
            },
            method:"POST",
            body: JSON.stringify(korisnik)
        });

        switch(response.status){
            case 200: {
                return response.json();
            }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async dodajDnevnik(dnevnik){

        let response = await fetch("http://localhost:5022/Diaries/CreateDiary",
        {
            headers:
            {
                Accept:"application/json",
                "Content-type":"application/json",
            },
            method:"POST",
            body: JSON.stringify(dnevnik)
        });

        switch(response.status){
            case 200: {
                return response.json();
            }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async dodajStranu(strana){

        let response = await fetch("http://localhost:5022/Pages/CreatePage",
        {
            headers:
            {
                Accept:"application/json",
                "Content-type":"application/json",
            },
            method:"POST",
            body: JSON.stringify(strana)
        });

        switch(response.status){
            case 200: {
                return response.json();
            }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }
    //////////////PUT
    async updateStranicu(strana){

        let response = await fetch("http://localhost:5022/Pages/UpdatePage",
        {
            headers:
            {
                Accept:"application/json",
                "Content-type":"application/json",
            },
            method:"PUT",
            body: JSON.stringify(strana)
        });

        switch(response.status){
            case 200: {
                return response.json();
            }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async updateDnevnik(dnevnik){

        let response = await fetch("http://localhost:5022/Diaries/UpdateDiary",
        {
            headers:
            {
                Accept:"application/json",
                "Content-type":"application/json",
            },
            method:"PUT",
            body: JSON.stringify(dnevnik)
        });

        switch(response.status){
            case 200: {
                return response.json();
            }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async updateKorisnik(kor){

        let response = await fetch("http://localhost:5022/Users/UpdateUser",
        {
            headers:
            {
                Accept:"application/json",
                "Content-type":"application/json",
            },
            method:"PUT",
            body: JSON.stringify(kor)
        });

        switch(response.status){
            case 200: {
                return response.json();
            }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }
    async updateKorisnikEmail(kor){

        let response = await fetch("http://localhost:5022/Users/UpdateUserEmail",
        {
            headers:
            {
                Accept:"application/json",
                "Content-type":"application/json",
            },
            method:"PUT",
            body: JSON.stringify(kor)
        });

        switch(response.status){
            case 200: {
                return true;
            }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                alert("Postoji korisnik sa to email adresom!")
                return false;
            }
        }
    }
    async updateKorisnikUsername(kor){

        let response = await fetch("http://localhost:5022/Users/UpdateUserUsername",
        {
            headers:
            {
                Accept:"application/json",
                "Content-type":"application/json",
            },
            method:"PUT",
            body: JSON.stringify(kor)
        });

        switch(response.status){
            case 200: {
                return true;
            }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                alert("Postoji korisnik s tim username-om");
                return false;
            }
        }
    }
    //////////////GET
    async getAllUsers()
    {
        var list=[]
        let response= await fetch("http://localhost:5022/Users/GetAllUsers", 
        {
            method:"GET"
        });
        switch(response.status)
        {
            case 200:
                {
                    var data= await response.json();
                    data.forEach(el => {
                        const korisnik= new User(el.id,el.name,el.lastName,el.email,el.username,el.password,el.diary,el.birthday);
                        list.push(korisnik)
                    });
                   return list;
                }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async getUserById(id)
    {
        let response= await fetch("http://localhost:5022/Users/GetUserById/"+id, 
        {
            method:"GET"
        });
        switch(response.status)
        {
            case 200:
                {
                    var el= await response.json();
                    const korisnik= new User(el.id,el.name,el.lastName,el.email,el.username,el.password,el.diary,el.birthday);
                    return korisnik;
                }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async prijavaKorisnika(email,pass)
    {
        let response= await fetch("http://localhost:5022/Users/prijaviSeNaSajt/"+email+"/"+pass,
        {
            method:"GET"
        });
        switch(response.status)
        {
            case 200:
                {
                    var el= await response.json();
                    const korisnik= new User(el.id,el.name,el.lastName,el.email,el.username,el.password,el.diary,el.birthday);
                    return korisnik;
                }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async getAllDiaries()
    {
        var list=[]
        let response= await fetch("http://localhost:5022/Diaries/GetAllDiaries", 
        {
            method:"GET"
        });
        switch(response.status)
        {
            case 200:
                {
                    var data= await response.json();
                    data.forEach(el => {
                        const dnevnik= new Diary(el.id,el.name,el.user,el.password,el.pages);
                        list.push(dnevnik)
                    });
                   return list;
                }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async getDiaryById(id)
    {
        let response= await fetch("http://localhost:5022/Diaries/GetDiaryById/"+id, 
        {
            method:"GET"
        });
        switch(response.status)
        {
            case 200:
                {
                    var el= await response.json();
                    const dnevnik= new Diary(el.id,el.name,el.user,el.password,el.pages);
                    return dnevnik;
                }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }
    async unlockDiary(id,pass)
    {
        let response= await fetch("http://localhost:5022/Diaries/unlockDiary/"+id+"/"+pass,
        {
            method:"GET"
        });
        switch(response.status)
        {
            case 200:
                {
                    var el= await response.json();
                    const dnevnik= new Diary(el.id,el.name,el.user,el.password,el.pages);
                    return dnevnik;
                }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async getAllPages()
    {
        var list=[]
        let response= await fetch("http://localhost:5022/Pages/GetAllPages", 
        {
            method:"GET"
        });
        switch(response.status)
        {
            case 200:
                {
                    var data= await response.json();
                    data.forEach(el => {
                        const strana= new Page(el.id,el.diary,el.feeling,el.weather,el.pageContent,el.datetime);
                        list.push(strana)
                    });
                   return list;
                }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async getPageById(id)
    {
        let response= await fetch("http://localhost:5022/Pages/GetPageById/"+id, 
        {
            method:"GET"
        });
        switch(response.status)
        {
            case 200:
                {
                    var el= await response.json();
                    const stranica= new Page(el.id,el.diary,el.feeling,el.weather,el.pageContent,el.datetime);
                    return stranica;
                }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async getPagesByDate(date)
    {
        var list=[]
        let response= await fetch("http://localhost:5022/Pages/GetPageByDate/"+date, 
        {
            method:"GET"
        });
        switch(response.status)
        {
            case 200:
                {
                    var data= await response.json();
                    data.forEach(el=>{
                        const stranica= new Page(el.id,el.diary,el.feeling,el.weather,el.pageContent,el.datetime);
                        list.push(stranica)
                    })
                    return list;
                }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }
    //////////////DELETE
    async deleteKorisnika(id)
    {
        let response= await fetch("http://localhost:5022/Users/DeleteUser/"+id,
        {
            method:"DELETE"
        });
        switch(response.status){
            case 200: {
                console.log(`Uspesno izbrisan korisnik!`);
                return true;
            }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async deleteDnevnik(id)
    {
        let response= await fetch("http://localhost:5022/Diaries/DeleteDiary/"+id,
        {
            method:"DELETE"
        });
        switch(response.status){
            case 200: {
                console.log(`Uspesno izbrisan dnevnik!`);
                return true;
            }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }

    async deleteStranicu(id)
    {
        let response= await fetch("http://localhost:5022/Pages/DeletePage/"+id,
        {
            method:"DELETE"
        });
        switch(response.status){
            case 200: {
                console.log(`Uspesno izbrisana stranica!`);
                return true;
            }
            case 400:{
                console.log(`Client error: ${await response.text()}`);
                return false;
            }
            default:{
                console.log(`Server error: ${await response.text()}`);
                return false;
            }
        }
    }
}