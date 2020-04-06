alter table dbo.Posts 
ADD CONSTRAINT fk_Posts
foreign key (CategoryId)
references Categories(CategoryId)

alter table dbo.Studies 
ADD CONSTRAINT fk_Studies
foreign key (CategoryId)
references Categories(CategoryId)