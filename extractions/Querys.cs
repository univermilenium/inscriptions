using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace univer.extractions
{
    public static class Querys
    {
         public const string SALUD   = "SALUD";
         public const string HIDALGO = "HIDALGO";
         public const string RAYON   = "RAYON";
         public const string NEZA    = "NEZA";
         public const string IXTAPA  = "IXTAPA";

        static public string salud() 
        {
            return @"SELECT DISTINCT
                      A.MATRICULA,
                      A.NOMBRE,
                      A.PATERNO,
                      A.MATERNO,
                      A.EMAIL,
                      B.CODIGOGRUPO,
                      D.CLAVEASIGNATURA,
                      A.ID_ESCUELA
                    FROM
                      ALUMNOS A,
                      ALUMNOS_GRUPOS B,
                      GRUPOS C,
                      ALUMNOS_KARDEX D,
                      CFGPLANES_MST E
  
                    WHERE 
                      A.ID_ESCUELA = 5 AND A.STATUS = 'A' AND (A.GRADO = 1 OR GRADO = 4) AND 
                      (A.MATRICULA LIKE '580%' OR A.MATRICULA LIKE '584%' OR A.MATRICULA LIKE '581%' OR A.MATRICULA LIKE '582%')	

                      AND A.NUMEROALUMNO  = B.NUMEROALUMNO
                      AND B.PERIODO       = 1
                      AND B.CODIGOGRUPO   LIKE 'S%'
                      AND B.INICIAL       = 2013
                      AND B.FINAL         = 2013
                      AND B.CODIGOGRUPO   = C.CODIGOGRUPO
                      AND C.INICIAL       = 2013
                      AND C.FINAL         = 2013
                      AND C.PERIODO       = 1
                      AND (C.GRADO =1 OR C.GRADO = 4)
  
                      AND A.NUMEROALUMNO  = D.NUMEROALUMNO
                      AND A.NIVEL         = E.NIVEL
                      AND D.ID_PLAN       = E.ID_PLAN
                      AND D.ID_EVAL       = 'A'
                      AND D.CALIFICACION_1= 0  
                      AND (
                            D.CLAVEASIGNATURA = 'MPS0101' 
                        )
  
                    ORDER BY b.CODIGOGRUPO				";
        }

        static public string rayon() 
        {
            return @"SELECT DISTINCT
                      A.MATRICULA,
                      A.NOMBRE,
                      A.PATERNO,
                      A.MATERNO,
                      A.EMAIL,
                      B.CODIGOGRUPO,
                      D.CLAVEASIGNATURA,
                      A.ID_ESCUELA
                    FROM
                      ALUMNOS A,
                      ALUMNOS_GRUPOS B,
                      GRUPOS C,
                      ALUMNOS_KARDEX D,
                      CFGPLANES_MST E
  
                    WHERE 
                      A.ID_ESCUELA = 1 AND A.STATUS = 'A' AND (A.GRADO = 1 OR GRADO = 4) AND 
                      (A.MATRICULA LIKE '180%' OR A.MATRICULA LIKE '184%' OR A.MATRICULA LIKE '181%' OR A.MATRICULA LIKE '182%')		

                      AND A.NUMEROALUMNO  = B.NUMEROALUMNO
                      AND B.PERIODO       = 1
                      AND B.CODIGOGRUPO   LIKE 'S%'
                      AND B.INICIAL       = 2013
                      AND B.FINAL         = 2013
                      AND B.CODIGOGRUPO   = C.CODIGOGRUPO
                      AND C.INICIAL       = 2013
                      AND C.FINAL         = 2013
                      AND C.PERIODO       = 1
                      AND (C.GRADO =1 OR C.GRADO = 4)
  
                      AND A.NUMEROALUMNO  = D.NUMEROALUMNO
                      AND A.NIVEL         = E.NIVEL
                      AND D.ID_PLAN       = E.ID_PLAN
                      AND D.ID_EVAL       = 'A'
                      AND D.CALIFICACION_1= 0  
                      AND (
                            D.CLAVEASIGNATURA = 'MDER0101' 
                         OR D.CLAVEASIGNATURA = 'CRIM0103'
                        )
  
                    ORDER BY b.CODIGOGRUPO		
                    ";
        }

        static public string neza() 
        {
            return @"SELECT DISTINCT
                      A.MATRICULA,
                      A.NOMBRE,
                      A.PATERNO,
                      A.MATERNO,
                      A.EMAIL,
                      B.CODIGOGRUPO,
                      D.CLAVEASIGNATURA,
                      A.ID_ESCUELA
                    FROM
                      ALUMNOS A,
                      ALUMNOS_GRUPOS B,
                      GRUPOS C,
                      ALUMNOS_KARDEX D,
                      CFGPLANES_MST E
  
                    WHERE 
                      A.ID_ESCUELA = 2 AND A.STATUS = 'A' AND (A.GRADO = 1 OR A.GRADO = 4) AND 
                      (A.MATRICULA LIKE '280%' OR A.MATRICULA LIKE '284%' OR A.MATRICULA LIKE '281%' OR A.MATRICULA LIKE '282%')

                      AND A.NUMEROALUMNO  = B.NUMEROALUMNO
                      AND B.PERIODO       = 1
                      AND B.CODIGOGRUPO   LIKE 'S%'
                      AND B.INICIAL       = 2013
                      AND B.FINAL         = 2013
                      AND B.CODIGOGRUPO   = C.CODIGOGRUPO
                      AND C.INICIAL       = 2013
                      AND C.FINAL         = 2013
                      AND C.PERIODO       = 1
                      AND (C.GRADO =1 OR C.GRADO = 4)
                      --()AND C.GRAD0 =
  
                      AND A.NUMEROALUMNO = D.NUMEROALUMNO
                      AND A.NIVEL = E.NIVEL
                      AND D.ID_PLAN = E.ID_PLAN
                      AND D.ID_EVAL = 'A'
                      AND D.CALIFICACION_1 = 0
                      --AND A.NIVEL = D.ID_PLAN --*****
  
                      AND (
		                    D.CLAVEASIGNATURA = 'MPS0101' 
                         OR D.CLAVEASIGNATURA = 'CRIM0103' 
                         OR D.CLAVEASIGNATURA = 'MPEG-0103' 
                         OR D.CLAVEASIGNATURA = 'MPEG-0418'
                         OR D.CLAVEASIGNATURA = 'MDER101'
                        )
  
                    order by b.CODIGOGRUPO";
        }

        static public string ixtapaluca() 
        {
            return @"SELECT DISTINCT
                      A.MATRICULA,
                      A.NOMBRE,
                      A.PATERNO,
                      A.MATERNO,
                      A.EMAIL,
                      B.CODIGOGRUPO,
                      D.CLAVEASIGNATURA,
                      A.ID_ESCUELA
                    FROM
                      ALUMNOS A,
                      ALUMNOS_GRUPOS B,
                      GRUPOS C,
                      ALUMNOS_KARDEX D,
                      CFGPLANES_MST E
  
                    WHERE 
                      A.ID_ESCUELA = 3 AND A.STATUS = 'A' AND (A.GRADO = 1 OR GRADO = 4) AND 
                      (A.MATRICULA LIKE '380%' OR A.MATRICULA LIKE '384%' OR A.MATRICULA LIKE '381%' OR A.MATRICULA LIKE '382%')

                      AND A.NUMEROALUMNO  = B.NUMEROALUMNO
                      AND B.PERIODO       = 1
                      AND B.CODIGOGRUPO   LIKE 'S%'
                      AND B.INICIAL       = 2013
                      AND B.FINAL         = 2013
                      AND B.CODIGOGRUPO   = C.CODIGOGRUPO
                      AND C.INICIAL       = 2013
                      AND C.FINAL         = 2013
                      AND C.PERIODO       = 1
                      AND (C.GRADO =1 OR C.GRADO = 4)
  
                      AND A.NUMEROALUMNO  = D.NUMEROALUMNO
                      AND A.NIVEL         = E.NIVEL
                      AND D.ID_PLAN       = E.ID_PLAN
                      AND D.ID_EVAL       = 'A'
                      AND D.CALIFICACION_1= 0  
                      AND (
                            D.CLAVEASIGNATURA = 'MPS0101' 
                         OR D.CLAVEASIGNATURA = 'MPEG0103'
                         OR D.CLAVEASIGNATURA = 'MPEG0418'
                         OR D.CLAVEASIGNATURA = 'MDER0101'
                         OR D.CLAVEASIGNATURA = 'CRIM0103'
                        )
  
                    ORDER BY b.CODIGOGRUPO	
                    ";

        }

        static public string hidalgo() 
        {
            return @"
                        SELECT DISTINCT
                          A.MATRICULA,
                          A.NOMBRE,
                          A.PATERNO,
                          A.MATERNO,
                          A.EMAIL,
                          B.CODIGOGRUPO,
                          D.CLAVEASIGNATURA,
                          A.ID_ESCUELA
                        FROM
                          ALUMNOS A,
                          ALUMNOS_GRUPOS B,
                          GRUPOS C,
                          ALUMNOS_KARDEX D,
                          CFGPLANES_MST E
  
                        WHERE 
                          A.ID_ESCUELA = 4 AND A.STATUS = 'A' AND (A.GRADO = 1 OR GRADO = 4) AND 
                          (A.MATRICULA LIKE '480%' OR A.MATRICULA LIKE '484%' OR A.MATRICULA LIKE '481%' OR A.MATRICULA LIKE '482%')	

                          AND A.NUMEROALUMNO  = B.NUMEROALUMNO
                          AND B.PERIODO       = 1
                          AND B.CODIGOGRUPO   LIKE 'S%'
                          AND B.INICIAL       = 2013
                          AND B.FINAL         = 2013
                          AND B.CODIGOGRUPO   = C.CODIGOGRUPO
                          AND C.INICIAL       = 2013
                          AND C.FINAL         = 2013
                          AND C.PERIODO       = 1
                          AND (C.GRADO =1 OR C.GRADO = 4)
  
                          AND A.NUMEROALUMNO  = D.NUMEROALUMNO
                          AND A.NIVEL         = E.NIVEL
                          AND D.ID_PLAN       = E.ID_PLAN
                          AND D.ID_EVAL       = 'A'
                          AND D.CALIFICACION_1= 0  
                          AND (
                                D.CLAVEASIGNATURA = 'MPEG-103' 
                             OR D.CLAVEASIGNATURA = 'MPEG-418'
                            )
  
                        ORDER BY b.CODIGOGRUPO	
                    ";
        }
    }
}
