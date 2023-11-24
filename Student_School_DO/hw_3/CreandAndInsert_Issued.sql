CREATE TABLE issued
(
	id_issued uniqueidentifier PRIMARY KEY,
	fk_id_reader uniqueidentifier REFERENCES readers(id_reader) NOT NULL,
	fk_id_book uniqueidentifier REFERENCES books(id_book) NOT NULL,
	date_issue DATE NOT NULL,
	date_due DATE NOT NULL
);

INSERT INTO issued
	VALUES
		(NEWID(),'10D63457-4338-408E-892B-A1B6675051A8','8C8D269D-F54D-4339-8A82-38DF8C748DA8','2023-08-10','2023-09-03'),
		(NEWID(),'2BA1B6B9-B3A2-4DF8-A066-8C8C436936FF','DE8DFCAD-7B05-4B04-A88E-7EB03F4CB708','2023-08-12','2023-08-25'),
		(NEWID(),'2BA1B6B9-B3A2-4DF8-A066-8C8C436936FF','06D5D032-6563-4C14-ADCC-C1918BAA2A8F','2023-08-15','2023-08-30'),
		(NEWID(),'897FF5B1-78FA-4B31-B200-99329E78CB8C','C988E38F-4809-4A3F-BB44-1FA4E4FC61AB','2023-08-17','2023-08-31'),
		(NEWID(),'9509849F-C97B-4F92-9688-E9EC01730E2D','8C8D269D-F54D-4339-8A82-38DF8C748DA8','2023-08-17','2023-09-22'),
		(NEWID(),'92DAC638-2A79-4870-8745-2B6DF879214E','5504B5AC-5060-42F6-A219-5D505A425ECA','2023-08-18','2023-08-21'),
		(NEWID(),'92DAC638-2A79-4870-8745-2B6DF879214E','D8A661A8-2F91-46B1-A32E-5192F1D104E4','2023-08-18','2023-08-21'),
		(NEWID(),'897FF5B1-78FA-4B31-B200-99329E78CB8C','06D5D032-6563-4C14-ADCC-C1918BAA2A8F','2023-08-20','2023-08-29'),
		(NEWID(),'10D63457-4338-408E-892B-A1B6675051A8','A3F56CDD-6699-4F6F-B18E-C89310BCE58C','2023-08-15','2023-10-15');