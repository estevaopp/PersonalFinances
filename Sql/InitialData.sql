INSERT INTO "UserRoles"("Name", "Description")
VALUES ('Regular', 'Usuario comum que tem acesso a coisas não administrativas e somente acesso a propria conta'),
       ('Admin', 'Usuario com acesso a tudo no sistema');

--Senha admin = "Admin123?"
INSERT INTO "Users"("Username", "Email", "Password", "IsEmailValid", "CreationDate", "UserRoleId")
VALUES ('admin', 'admin@admin', '$2y$12$hSqbsQsNPMLQFh8/Iv3sPO1j8oNi//0lb2C9nLgFzrSfMkTTKLrKe', '1', now(), '2');