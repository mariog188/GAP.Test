export interface Poliza {
  IdPoliza: number;
  Cedula: number;
  Nombre: string;
  Descripcion: string;
  FechaInicio: Date;
  PeriodoCobertura: number;
  Precio: number;
  TipoCobertura: number;
  TipoRiesgo: number;
}

export interface Cliente {
  Nombre: string;
  Apellido: string;
  Cedula: number;
}

export interface TipoCobertura {
  Nombre: string;
  Id: number;
}

export interface TipoRiesgo {
  Nombre: string;
  Id: number;
}
