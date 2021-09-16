CREATE TABLE observations (
    id serial PRIMARY KEY,
    description TEXT NOT NULL UNIQUE
);