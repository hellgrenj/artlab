CREATE TABLE observations (
    id serial PRIMARY KEY,
    description TEXT NOT NULL,
    city TEXT NOT NULL,
    lat TEXT NOT NULL,
    long TEXT NOT NULL
);