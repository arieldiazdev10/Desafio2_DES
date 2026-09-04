CREATE DATABASE Gestion_Eventos;


USE Gestion_Eventos;
GO

-- Eventos
CREATE TABLE Eventos (
    id_evento INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    fecha DATE NOT NULL,
    lugar NVARCHAR(100) NOT NULL
);
GO

-- Participantes
CREATE TABLE Participantes (
    id_participante INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    id_evento INT NOT NULL,
    CONSTRAINT fk_participante_evento FOREIGN KEY (id_evento) 
        REFERENCES eventos(id_evento) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
);
GO

-- Organizadores
CREATE TABLE Organizadores (
    id_organizador INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL,
    cargo NVARCHAR(50) NOT NULL,
    id_evento INT NOT NULL,
    CONSTRAINT fk_organizador_evento FOREIGN KEY (id_evento) 
        REFERENCES eventos(id_evento) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
);
GO


USE Gestion_Eventos;
GO

-- =========================================================
-- POBLADO DE LA TABLA EVENTOS
-- =========================================================

INSERT INTO Eventos (nombre, fecha, lugar)
VALUES
('Conferencia de Tecnología 2026', '2026-09-15', 'Centro de Convenciones San Salvador'),
('Feria Internacional de Innovación', '2026-09-20', 'CIFCO'),
('Taller de Desarrollo Web', '2026-09-25', 'Universidad de El Salvador'),
('Congreso de Inteligencia Artificial', '2026-10-05', 'Hotel Barceló San Salvador'),
('Seminario de Seguridad Informática', '2026-10-10', 'Centro Cultural de España'),
('Hackathon El Salvador 2026', '2026-10-18', 'Universidad Don Bosco'),
('Feria de Emprendimiento', '2026-10-25', 'Centro Internacional de Ferias y Convenciones'),
('Workshop de Bases de Datos', '2026-11-02', 'Universidad Tecnológica de El Salvador'),
('Foro de Transformación Digital', '2026-11-12', 'Hotel Sheraton Presidente'),
('Expo Tecnología y Futuro', '2026-11-20', 'Centro de Convenciones San Salvador');
GO


-- =========================================================
-- POBLADO DE LA TABLA PARTICIPANTES
-- =========================================================

INSERT INTO Participantes (nombre, email, id_evento)
VALUES
-- Evento 1
('Carlos Martínez', 'carlos.martinez@email.com', 1),
('Ana López', 'ana.lopez@email.com', 1),
('Luis Hernández', 'luis.hernandez@email.com', 1),

-- Evento 2
('María González', 'maria.gonzalez@email.com', 2),
('José Ramírez', 'jose.ramirez@email.com', 2),
('Sofía Castillo', 'sofia.castillo@email.com', 2),

-- Evento 3
('Daniel Flores', 'daniel.flores@email.com', 3),
('Laura Pérez', 'laura.perez@email.com', 3),
('Miguel Torres', 'miguel.torres@email.com', 3),

-- Evento 4
('Andrea Rodríguez', 'andrea.rodriguez@email.com', 4),
('Fernando Morales', 'fernando.morales@email.com', 4),
('Gabriela Cruz', 'gabriela.cruz@email.com', 4),

-- Evento 5
('Ricardo Sánchez', 'ricardo.sanchez@email.com', 5),
('Patricia Mendoza', 'patricia.mendoza@email.com', 5),
('Jorge Ramírez', 'jorge.ramirez@email.com', 5),

-- Evento 6
('Diego Herrera', 'diego.herrera@email.com', 6),
('Valeria Castro', 'valeria.castro@email.com', 6),
('Roberto Núñez', 'roberto.nunez@email.com', 6),

-- Evento 7
('Camila Vásquez', 'camila.vasquez@email.com', 7),
('Oscar Aguilar', 'oscar.aguilar@email.com', 7),
('Natalia Romero', 'natalia.romero@email.com', 7),

-- Evento 8
('Eduardo Martínez', 'eduardo.martinez@email.com', 8),
('Paola Rivera', 'paola.rivera@email.com', 8),
('Alejandro Díaz', 'alejandro.diaz@email.com', 8),

-- Evento 9
('Verónica Pérez', 'veronica.perez@email.com', 9),
('Héctor García', 'hector.garcia@email.com', 9),
('Claudia Fuentes', 'claudia.fuentes@email.com', 9),

-- Evento 10
('Samuel Torres', 'samuel.torres@email.com', 10),
('Isabel Molina', 'isabel.molina@email.com', 10),
('Mauricio Campos', 'mauricio.campos@email.com', 10);
GO


-- =========================================================
-- POBLADO DE LA TABLA ORGANIZADORES
-- =========================================================

INSERT INTO Organizadores (nombre, cargo, id_evento)
VALUES
-- Evento 1
('Alejandro Pérez', 'Coordinador General', 1),
('Beatriz Morales', 'Logística', 1),

-- Evento 2
('Ricardo Gómez', 'Director del Evento', 2),
('Lucía Hernández', 'Coordinadora', 2),

-- Evento 3
('Carlos Rodríguez', 'Instructor Principal', 3),
('Mónica Castro', 'Asistente', 3),

-- Evento 4
('Fernando López', 'Director Académico', 4),
('Gabriela Martínez', 'Coordinadora General', 4),

-- Evento 5
('Jorge Sánchez', 'Coordinador de Seguridad', 5),
('Patricia Torres', 'Logística', 5),

-- Evento 6
('Daniel Romero', 'Director del Hackathon', 6),
('Sofía Mendoza', 'Coordinadora Técnica', 6),

-- Evento 7
('Miguel Castillo', 'Director de Emprendimiento', 7),
('Laura Aguilar', 'Coordinadora', 7),

-- Evento 8
('Roberto Flores', 'Instructor', 8),
('Camila Ramírez', 'Coordinadora Académica', 8),

-- Evento 9
('Eduardo Cruz', 'Director del Foro', 9),
('Natalia Herrera', 'Relaciones Públicas', 9),

-- Evento 10
('Oscar Martínez', 'Director General', 10),
('Valeria Núñez', 'Coordinadora de Eventos', 10);
GO