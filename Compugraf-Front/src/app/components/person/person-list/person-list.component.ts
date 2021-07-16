import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Person } from 'src/app/models/person';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.scss']
})
export class PersonListComponent implements OnInit {

  constructor(private _personService: PersonService, private _router: Router, private _messageService: MessageService,
    private _confirmationService: ConfirmationService) { }

  public personList: Person[] = [];

  ngOnInit(): void {
    this.getAllPerson()
  }

  public getAllPerson() {
    this._personService.getAllPerson().subscribe((response: any) => {
      this.personList = response;
    });
  }

  handleEditPerson(id: number) {
    this._router.navigate([`person/${id}`]);
  }

  handleRemovePerson(id: number) {
    this._confirmationService.confirm({
      message: 'Tem certeza que deseja excluir esta pessoa?',
      accept: () => {
        this._personService.deletePerson(id).subscribe(() => {
          this._messageService.add({ severity: 'success', summary: "Sucesso", detail: "Pessoa excluída com sucesso" });
          this.getAllPerson();
        },
          (error: any) => {
            var errorObj = error?.error?.errors;
            const errorList = Object.keys(errorObj).map(x => errorObj[x]);

            errorList.map(x => {
              this._messageService.add({ severity: 'error', summary: "Erro", detail: x[0] });
            });
          });
      }
    });
  }
}
