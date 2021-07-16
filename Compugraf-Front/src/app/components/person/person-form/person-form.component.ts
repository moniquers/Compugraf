import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.scss']
})
export class PersonFormComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private _personService: PersonService,
    private _activatedRoute: ActivatedRoute, private _router: Router, private _messageService: MessageService) {
  }

  personForm: FormGroup = this.formBuilder.group({
    id: [''],
    name: ['', Validators.required],
    lastName: ['', Validators.required],
    cpf: ['', [Validators.required]],
    email: ['', [Validators.required]],
    nationality: ['', [Validators.required]],
    zipCode: ['', [Validators.required]],
    address: ['', [Validators.required]],
    city: ['', [Validators.required]],
    state: ['', [Validators.required]],
    phoneNumber: ['', [Validators.required]],
  })!;

  ngOnInit(): void {

    const personId = this._activatedRoute.snapshot.paramMap.get("id");
    if (personId)
      this.editPersonFillForm(parseInt(personId));
  }

  public handleSubmitPerson() {

    if (!this.personForm?.valid)
      return;

    if (this.personForm?.get("id")?.value) {

      this._personService.updatePerson(this.personForm.value).subscribe(() => {
        this._messageService.add({ severity: 'success', summary: "Sucesso", detail: "Cadastro alterado com sucesso" });
        this._router.navigate(['persons']);
      },
        (error) => {
          var errorObj = error?.error?.errors;

          if (errorObj === undefined)
            errorObj = { "Error": [error?.error] }

          const errorList = Object.keys(errorObj).map(x => errorObj[x]);

          errorList.map(x => {
            this._messageService.add({ severity: 'error', summary: "Erro", detail: x[0] });
          });
        });
    }
    else {
      this._personService.createPerson(this.personForm.value).subscribe(() => {
        this._messageService.add({ severity: 'success', summary: "Sucesso", detail: "Cadastro realizado com sucesso" });
        this._router.navigate(['persons']);
      },
        (error) => {

          var errorObj = error?.error?.errors;

          if (errorObj === undefined)
            errorObj = { "Error": [error?.error] }

          const errorList = Object.keys(errorObj).map(x => errorObj[x]);

          errorList.map(x => {
            this._messageService.add({ severity: 'error', summary: "Erro", detail: x[0] });
          });
        });
    }
  }

  editPersonFillForm(id: number) {
    this._personService.getPersonById(id).subscribe((response: any) => {
      this.personForm.setValue({
        id: response.id,
        name: response.name,
        lastName: response.lastName,
        email: response.email,
        cpf: response.cpf,
        nationality: response.nationality,
        zipCode: response.zipCode,
        address: response.address,
        city: response.city,
        state: response.state,
        phoneNumber: response.phoneNumber,
      });
    });
  }

  findAddressByZipCode() {

    const zipCodeValue = this.personForm.get('zipCode')?.value;
    const zipCode = zipCodeValue?.replace(/\D/g, '');

    if (zipCode != "") {

      var validateZipCode = /^[0-9]{8}$/;

      if (validateZipCode.test(zipCode)) {
        this._personService.getAddressByZipCode(zipCode).subscribe((response) => {
          this.personForm.patchValue({
            address: response.logradouro,
            city: response.localidade,
            state: response.uf
          });
        })
      }
      else {
        this.cleanAdressFields();
      }
    }
    else {
      this.cleanAdressFields();
    }
  };

  cleanAdressFields() {
    this.personForm.patchValue({
      address: "",
      city: "",
      state: ""
    });
  }

}

