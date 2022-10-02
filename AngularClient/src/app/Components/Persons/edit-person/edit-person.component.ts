import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from 'src/app/Models/Person.model';
import { PersonsService } from 'src/app/Services/persons.service';
import { LocalizationService } from 'src/app/Services/localization.service';

@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrls: ['./edit-person.component.scss']
})
export class EditPersonComponent implements OnInit {

  editedPerson: Person ={
    id: '',
    name: '',
    surname: '',
    gender: '',
    birthDate: '',
    birthPlace: '',
    taxCode: '',
    province:''
  };

  provinces: string[] =  [];

  municipalities: string[] = [];
  
  constructor(
    private route: ActivatedRoute,
    private personService: PersonsService,
    private localizationService : LocalizationService,
    private router: Router
  ) { }

  ngOnInit(): void {
    //get item from api
    this.route.paramMap.subscribe({
        next : (params) =>{
          const id = params.get('id');
          if(id)
          {
            this.personService.GetPersonById(id)
            .subscribe({
              next: (response) =>
              {
                this.editedPerson = response;
                this.getProvinces();
                this.onChangeProvince();
              }
            })
          }
        }
      })
    }

    UpdatePerson()
    {
      this.personService.UpdatePerson(this.editedPerson.id,this.editedPerson)
      .subscribe({
        next : (response) =>
        {
          this.router.navigate(['/persons']);
        }
      })
    }

    DeletePerson(id: string)
    {
      this.personService.DeletePersonById(id)
      .subscribe({
        next:(response)=>
        {
          this.router.navigate(['/persons']);
        }
      })
    }

    getProvinces(){
      this.localizationService.GetDistinctProvinces()
    .subscribe(
      {
        next: (provinces) =>{
          this.provinces = provinces;
          console.log(provinces);
      },
      error: (response) =>{console.log(response);}
      })
    }

    onChangeProvince(){
      this.localizationService.GetMunicipalitiesFromProvince(this.editedPerson.province)
      .subscribe(
        {
          next: (municipalities) =>{
            this.municipalities = municipalities;
            console.log(municipalities);
        },
        error: (response) =>{console.log(response);}
        })
    }

}
