create table datos_generales(
    no_reporte integer NOT NULL,
    coordinacion_zonal integer not null,
    conductor_entrega varchar not null,
    conductor_recibe varchar not null,
    provincia varchar not null,
    unidad_operativa varchar not null,
    alfa integer not null,
    base_operativa varchar,
    hora time not null,
    fecha date not null
);

create table preguntas (
    no_reporte integer not null,
    no_pregunta integer not null,
    estado boolean NOT NULL,
    observacion varchar
);

create table limpieza() inherits(preguntas);
create table cabina_interior() inherits(preguntas);
create table documentos() inherits(preguntas);
create table cabina_exterior() inherits(preguntas);




create table danos(
    no_reporte integer not null,
    imagen varchar not null
);

create table descripcion_danos(
    no_reporte integer not null,
    id_descripcion int not null,
    descripcion varchar
);


-- id_descripcion: campos del 1 al 18

create table otros_datos(
    no_reporte integer not null,
    combustible varchar not null,
    temperatura varchar not null,
    kilometraje int,
    observaciones_generales varchar
);



-------------------------------------------------------------
---------------- Constraints -------------------------------
------------------------------------------------------------

-- Primary key
alter table datos_generales add constraint pkey_no_reporte primary key (no_reporte); 


-- Foreign Key
alter table preguntas add constraint fkey_no_reporte foreign key(no_reporte) references  datos_generales(no_reporte);
alter table limpieza add constraint fkey_no_reporte foreign key(no_reporte) references  datos_generales(no_reporte);
alter table cabina_interior add constraint fkey_no_reporte foreign key(no_reporte) references  datos_generales(no_reporte);
alter table documentos add constraint fkey_no_reporte foreign key(no_reporte) references  datos_generales(no_reporte);
alter table cabina_exterior add constraint fkey_no_reporte foreign key(no_reporte) references  datos_generales(no_reporte);
alter table danos add constraint fkey_no_reporte foreign key(no_reporte) references  datos_generales(no_reporte);
alter table descripcion_danos add constraint fkey_no_reporte foreign key(no_reporte) references  datos_generales(no_reporte);
alter table otros_datos add constraint fkey_no_reporte foreign key(no_reporte) references  datos_generales(no_reporte);


