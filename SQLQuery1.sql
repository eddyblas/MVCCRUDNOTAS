Create database MvcCrud
use MvcCrud

Create table ActaNotas(
IdNotasE int identity (1,1) primary key,
Carnet nvarchar(12),
Nombre nvarchar(30),
Apellido nvarchar(30),
IPN smallint,
IIPN smallint,
Siste smallint,
Proyect smallint,
NF smallint
)

Create trigger Tr_NotaF

on dbo.ActaNotas after insert as update ActaNotas set NF=IPN+IIPN+Proyect+Siste

  

Create trigger Tr_NotaFinal

on dbo.ActaNotas after update as update ActaNotas set NF=IPN+IIPN+Proyect+Siste 