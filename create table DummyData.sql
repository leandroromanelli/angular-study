create table [DummyData]
(
	[ID]				int				not null identity (1, 1),
	[Name]				varchar(max)	not null,
	[EmailID]			varchar(max)	not null,
	[PhoneNumber]		varchar(max)	not null,
	[UpdatedDateTime]	datetime		not null,

	primary key ([ID])
)