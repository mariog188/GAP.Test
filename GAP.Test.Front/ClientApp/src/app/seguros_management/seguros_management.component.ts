import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { FormControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource, MatOptionModule } from '@angular/material';
import { Poliza, Cliente, TipoCobertura, TipoRiesgo } from './poliza.interface';
import { HttpClient } from '@angular/common/http';
import { switchMap } from 'rxjs/operators';


@Component({
  selector: 'app-seguros_management',
  templateUrl: './seguros_management.component.html',
  styleUrls: ['./seguros_management.component.css'],
})
export class Seguros_managementComponent implements OnInit {
  urlpoliza = this.baseUrl + 'api/Poliza';
  urlcliente = this.baseUrl + 'api/Cliente';
  urltipocobertura = this.baseUrl + 'api/TipoCobertura';
  urltiporiesgo = this.baseUrl + 'api/TipoRiesgo';
	dataSource: MatTableDataSource<Poliza>;
	displayedColumns: string[] = [
	'IdPoliza'	,
	'Cedula',
	'Nombre',
	'Descripcion',
	'FechaInicio',
	'PeriodoCobertura',
	'Precio',
	'TipoCobertura',
    'TipoRiesgo',
    'actionsColumn',
	];
  poliza: Poliza;
//   clientes$: Observable<{Cliente}>;
	clientes: Cliente[];
	tiposcoberturas: TipoCobertura[];
	tiposriesgos: TipoRiesgo[];
	selectedCliente: number;
	selectedTipoCobertura: number;
	selectedTipoRiesgo: number;
	form: FormGroup;
	showform = false;
	update = false;


  constructor(
    private http: HttpClient,
    private formbuilder: FormBuilder,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  ngOnInit() {
    debugger;
    this.getPolizas();
		this.form = this.formbuilder.group({
		idPoliza: [ '', [ Validators.required ] ],
		cedula: [ null ],
		nombre: [ '', [ Validators.required ] ],
		descripcion: [ '', [ Validators.required ] ],
		periodoCobertura: [ '', [ Validators.required ] ],
		precio: [ '', [ Validators.required ] ],
			// age: [ 0, [ Validators.min(15), Validators.max(99) ] ],
		fechaInicio: [ '', [ Validators.required ] ],
		tipoCobertura: [ null ],
		tipoRiesgo:  [ null ],
		});
  }

	getPolizas() {
		this.http
      .get<Poliza[]>(this.urlpoliza)
			.subscribe((data: Poliza[]) => {
				this.dataSource = new MatTableDataSource(data);
			});
  }

  getClientes() {
	this.http.get(this.urlcliente).subscribe((resp: Cliente[]) => (this.clientes = resp));
  }
  
  getTiposCoberturas() {
	this.http.get(this.urltipocobertura).subscribe((resp: TipoCobertura[]) => (this.tiposcoberturas = resp));
  }

  getTiposRiesgos() {
	this.http.get(this.urltiporiesgo).subscribe((resp: TipoRiesgo[]) => (this.tiposriesgos = resp));
  }
  
  addPolizas() {
    this.http.post(this.urlpoliza, this.poliza);
  }
  
  deletePoliza(selectedPoliza: Poliza) {
    const deleteurl = this.urlpoliza + '/' + selectedPoliza.Cedula;
		this.http
			.delete<Poliza[]>(deleteurl)
			.pipe(
				switchMap(() => this.http.get<Poliza[]>(this.urlpoliza)),
			)
			.subscribe((result) => {
				this.dataSource = new MatTableDataSource(result);
			});
	}

  createNew() {
	this.update = false;
	this.showform = !this.showform;
	this.getClientes();
	this.getTiposCoberturas();
	this.getTiposRiesgos();
  }
  
  
	edit(selectedPoliza: Poliza) {
		this.update = true;
		this.showform = true;
		this.form.patchValue({
			idPoliza: selectedPoliza.IdPoliza,
			cedula: selectedPoliza.Cedula,
			nombre: selectedPoliza.Nombre,
			descripcion: selectedPoliza.Descripcion,
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
	  debugger;
		const poliza: Poliza = {
			IdPoliza: this.form.get('idPoliza').value,
			Cedula: this.selectedCliente,
			Nombre: this.form.get('nombre').value,
			Descripcion: this.form.get('descripcion').value,
			FechaInicio: this.form.get('fechaInicio').value,
			PeriodoCobertura: this.form.get('periodoCobertura').value,
			Precio: this.form.get('precio').value,
			TipoCobertura: this.selectedTipoCobertura,
			TipoRiesgo: this.selectedTipoRiesgo,
		};
		if (!this.update) {
			this.http
      .post(this.urlpoliza, poliza)
			.pipe(
         switchMap(() => this.http.get<Poliza[]>(this.urlpoliza)),
			)
			.subscribe((result) => {
				this.dataSource = new MatTableDataSource(result);
			});			
		}
		else{
			this.http
      .patch(this.urlpoliza, poliza)
			.pipe(
         switchMap(() => this.http.get<Poliza[]>(this.urlpoliza)),
			)
			.subscribe((result) => {
				this.dataSource = new MatTableDataSource(result);
			});
		}

		this.form.patchValue({
			idPoliza: '',
			cedula: '',
			nombre: '',
			escripcion: '',
			fechaInicio: '',
			periodoCobertura: '',
			precio: '',
			tipoCobertura: '',
			tipoRiesgo: '',
		});
	}
}
