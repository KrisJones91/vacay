use vacay2171;


-- CREATE TABLE vacay (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   price DECIMAL(5,2),

--   PRIMARY KEY (id)
-- );

-- CREATE TABLE trip (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   price INT NOT NULL,

--   PRIMARY KEY (id),

-- );
-- CREATE TABLE cruise (
--   id INT NOT NULL AUTO_INCREMENT,
--   title VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   start VARCHAR(255) NOT NULL,
--   end VARCHAR(255) NOT NULL,
--   length INT NOT NULL,
--   price INT NOT NULL,
--   tripId INT NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (tripId)
--     REFERENCES trip (id)
--     ON DELETE CASCADE
--);

-- CREATE TABLE rental (
--   id INT NOT NULL AUTO_INCREMENT,
--   car VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   duration VARCHAR(255) NOT NULL,
--   miles INT NOT NULL,
--   price INT NOT NULL,
--   tripId INT NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (tripId)
--     REFERENCES trip (id)
--     ON DELETE CASCADE
--);



-- DANGER ZONE

-- ALTER A TABLE
-- ALTER TABLE reviews
--   ADD COLUMN date DATE



-- DELETE ALL DATA WITHIN A COLLECTION
-- DELETE FROM reviews;

-- DELETE ENTIRE COLLECTION TABLE
-- DROP TABLE reviews;