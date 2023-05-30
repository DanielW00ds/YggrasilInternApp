Insert into Assets(name, notes, capacity, longitude, latitude, contractStart, contractEnd, modifiedBy, ModifiedAt, fk_Counterpart_ID, fk_Area_ID, fk_AssetType_ID,  fk_TechnologyType_ID, fk_State_ID)
Values('Benji', 'This is a test data note', 10.0, 56.9525126, 13.5898569, '2023-06-31', '2025-05-31', 'Daniel', '2023-05-23 07:30:45', (SELECT id FROM Counterparts WHERE id = 1), (SELECT id FROM Areas WHERE id = 3), (SELECT id FROM AssetTypes WHERE id = 1), (SELECT id FROM TechnologyTypes WHERE id = 1), (SELECT id FROM States WHERE id = 2))

Insert into Assets(name, notes, capacity, longitude, latitude, contractStart, contractEnd, modifiedBy, ModifiedAt, fk_Counterpart_ID, fk_Area_ID, fk_AssetType_ID,  fk_TechnologyType_ID, fk_State_ID)
Values('Giant', 'This is another test data note', 13.0, 59.9525126, 16.5898569, '2023-06-01', '2024-06-30', 'Daniel', '2023-05-23 07:30:45', (SELECT id FROM Counterparts WHERE id = 2), (SELECT id FROM Areas WHERE id = 2), (SELECT id FROM AssetTypes WHERE id = 1), (SELECT id FROM TechnologyTypes WHERE id = 1), (SELECT id FROM States WHERE id = 1))

Insert into Assets(name, notes, capacity, longitude, latitude, contractStart, contractEnd, modifiedBy, ModifiedAt, fk_Counterpart_ID, fk_Area_ID, fk_AssetType_ID,  fk_TechnologyType_ID, fk_State_ID)
Values('Boost', 'This is yet another test data note', 20.1, 66.9525126, 19.2378, '2023-05-01', '2023-05-30', 'Daniel', '2023-05-23 07:30:45', (SELECT id FROM Counterparts WHERE id = 3), (SELECT id FROM Areas WHERE id = 3), (SELECT id FROM AssetTypes WHERE id = 1), (SELECT id FROM TechnologyTypes WHERE id = 1), (SELECT id FROM States WHERE id = 1))

Select * from Assets
	