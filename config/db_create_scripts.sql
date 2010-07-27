
Create database if not exists gallerywebdb;

Grant ALL on garllerywebdb.* TO 'root'@'%';

CREATE TABLE Member (
  id INT(11) default NULL auto_increment,
username char(60) ,
password char(60) ,
  email char(60) ,
  PRIMARY KEY (id)
)
