import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material';
import { Poliza } from './poliza.interface';
import { HttpClient } from '@angular/common/http';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-seguros_management',
  templateUrl: './seguros_management.component.html',
  styleUrls: ['./seguros_management.component.css'],
})
export class Seguros_managementComponent implements OnInit {
	url =  this.baseUrl + 'api/Poliza';
	dataSource: MatTableDataSource<Poliza>;
	displayedColumns: string[] = [
		'Cedula',
		'Nombre',
		'Apellido',
		'FechaInicio',
		'PeriodoCobertura',
		'Precio',
		'TipoCobertura',
    'TipoRiesgo',
    'actionsColumn',
	];
	poliza: Poliza;
	form: FormGroup;
	showform = false;


  constructor(
    private http: HttpClient,
    private formbuilder: FormBuilder,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  ngOnInit() {
    debugger;
    this.getPolizas();
		this.form = this.formbuilder.group({
			cedula: [ null ],
			nombre: [ '', [ Validators.required ] ],
			apellido: [ '', [ Validators.required ] ],
      periodoCobertura: [ '', [ Validators.required ] ],
      precio: [ '', [ Validators.required ] ],
			// age: [ 0, [ Validators.min(15), Validators.max(99) ] ],
			fechaInicio: [ '', [ Validators.required ] ],
      tipoCobertura: [ '', [ Validators.required ] ],
      tipoRiesgo: [ '', [ Validators.required ] ],
		});
  }

	getPolizas() {
		this.http
			.get<Poliza[]>(this.url)
			.subscribe((data: Poliza[]) => {
				this.dataSource = new MatTableDataSource(data);
			});
  }
  
  addPolizas() {
		this.http.post(this.url, this.poliza);
  }
  
  deletePoliza(selectedPoliza: Poliza) {
		const deleteurl = this.url + '/' + selectedPoliza.Cedula;
		this.http
			.delete<Poliza[]>(deleteurl)
			.pipe(
				switchMap(() => this.http.get<Poliza[]>(this.url)),
			)
			.subscribe((result) => {
				this.dataSource = new MatTableDataSource(result);

				// this.editProjects(selectedPoliza.ProjectId, '-');
			});
	}

  createNew() {
		this.showform = !this.showform;
  }
  
  
	edit(selectedPoliza: Poliza) {
		this.showform = true;
		this.form.patchValue({
			cedula: selectedPoliza.Cedula,
			nombre: selectedPoliza.Nombre,
			apellido: selectedPoliza.Apellido,
			fechaInicio: selectedPoliza.FechaInicio,
			periodoCobertura: selectedPoliza.PeriodoCobertura,
      precio: selectedPoliza.Precio,
      tipoCobertura: selectedPoliza.TipoCobertura,
      tipoRiesgo: selectedPoliza.TipoRiesgo,
		});
	}

  delete(cedula) {
		this.deletePoliza(cedula);
  }
  
  save() {
		const poliza: Poliza = {
			Cedula: this.form.get('cedula').value,
			Nombre: this.form.get('nombre').value,
			Apellido: this.form.get('apellido').value,
			FechaInicio: this.form.get('fechaInicio').value,
			PeriodoCobertura: this.form.get('periodoCobertura').value,
      Precio: this.form.get('precio').value,
      TipoCobertura: this.form.get('tipoCobertura').value,
      TipoRiesgo: this.form.get('tipoRiesgo').value,
		};
		this.http
			.post(this.url, poliza)
			.pipe(
				switchMap(() => this.http.get<Poliza[]>(this.url)),
			)
			.subscribe((result) => {
				this.dataSource = new MatTableDataSource(result);
				// if (!poliza.Cedula) {
				// 	this.editProjects(employee.ProjectId, '+');
				// }
			});
		this.form.patchValue({
			cedula: '',
			nombre: '',
			apellido: '',
			fechaInicio: '',
			periodoCobertura: '',
      precio: '',
      tipoCobertura: '',
      tipoRiesgo: '',
		});
	}
}
