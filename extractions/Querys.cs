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
	                        G.CODIGOGRUPO,
	                        K.CLAVEASIGNATURA,
	                        A.ID_ESCUELA
                        FROM
	                        ALUMNOS_KARDEX K,
	                        ALUMNOS A,
	                        ALUMNOS_GRUPOS G,
	                        GRUPOS GR
                        WHERE
	                        A.NUMEROALUMNO    = K.NUMEROALUMNO AND
	                        A.NUMEROALUMNO    = G.NUMEROALUMNO AND
	                        G.PERIODO         = 1              AND 
	                        G.INICIAL         = 2013           AND 
	                        G.FINAL           = 2013           AND
	                        G.CODIGOGRUPO     = GR.CODIGOGRUPO AND
                                (GR.GRADO = 1 OR GR.GRADO = 4  ) AND
	                        G.CODIGOGRUPO LIKE 'S%'              AND 
	                        (K.CLAVEASIGNATURA = 'MPS0101')      AND
	                        K.ID_EVAL         = 'A'            AND
	                        K.CALIFICACION_1  = 0              AND
	                        A.STATUS          = 'A'            AND
	                        A.ID_ESCUELA      = 5              AND
	                        (A.MATRICULA LIKE '580%' OR A.MATRICULA LIKE '584%' OR A.MATRICULA LIKE '581%' OR A.MATRICULA LIKE '582%')		";
        }

        static public string rayon() 
        {
            return @"SELECT DISTINCT
	                    A.MATRICULA,
	                    A.NOMBRE,
	                    A.PATERNO,
	                    A.MATERNO,
	                    A.EMAIL,
	                    G.CODIGOGRUPO,
	                    K.CLAVEASIGNATURA,
	                    A.ID_ESCUELA
                    FROM
	                    ALUMNOS_KARDEX K,
	                    ALUMNOS A,
	                    ALUMNOS_GRUPOS G,
	                    GRUPOS GR
                    WHERE
	                    A.NUMEROALUMNO    = K.NUMEROALUMNO AND
	                    A.NUMEROALUMNO    = G.NUMEROALUMNO AND
	                    G.PERIODO         = 1              AND 
	                    G.INICIAL         = 2013           AND 
	                    G.FINAL           = 2013           AND
	                    G.CODIGOGRUPO     = GR.CODIGOGRUPO AND
                            (GR.GRADO = 1 OR GR.GRADO = 4  )   AND
	                    G.CODIGOGRUPO LIKE 'S%'            AND 
	                    (K.CLAVEASIGNATURA = 'MDER0101' OR K.CLAVEASIGNATURA = 'CRIM0103')      AND
	                    K.ID_EVAL         = 'A'            AND
	                    K.CALIFICACION_1  = 0              AND
	                    A.STATUS          = 'A'            AND
	                    A.ID_ESCUELA      = 1              AND
	                    (A.MATRICULA LIKE '180%' OR A.MATRICULA LIKE '184%' OR A.MATRICULA LIKE '181%' OR A.MATRICULA LIKE '182%')		
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
	                    G.CODIGOGRUPO,
	                    K.CLAVEASIGNATURA,
	                    A.ID_ESCUELA
                    FROM
	                    ALUMNOS_KARDEX K,
	                    ALUMNOS A,
	                    ALUMNOS_GRUPOS G,
	                    GRUPOS GR
                    WHERE
	                    A.NUMEROALUMNO    = K.NUMEROALUMNO AND
	                    A.NUMEROALUMNO    = G.NUMEROALUMNO AND
	                    G.PERIODO         = 1              AND 
	                    G.INICIAL         = 2013           AND 
	                    G.FINAL           = 2013           AND
	                    G.CODIGOGRUPO     = GR.CODIGOGRUPO AND
                            (GR.GRADO = 1 OR GR.GRADO = 4  )   AND
	                    G.CODIGOGRUPO LIKE 'S%'            AND 
	                    (K.CLAVEASIGNATURA = 'MPS0101' OR K.CLAVEASIGNATURA = 'MPEG-0103' OR K.CLAVEASIGNATURA = 'MPEG-0418' OR K.CLAVEASIGNATURA = 'MDER101' OR K.CLAVEASIGNATURA = 'CRIM0103')      AND
	                    K.ID_EVAL         = 'A'            AND
	                    K.CALIFICACION_1  = 0              AND
	                    A.STATUS = 'A'                     AND
	                    A.ID_ESCUELA = 2 AND
	                    (A.MATRICULA LIKE '280%' OR A.MATRICULA LIKE '284%' OR A.MATRICULA LIKE '281%' OR A.MATRICULA LIKE '282%')
                    ";
        }

        static public string ixtapaluca() 
        {
            return @"SELECT DISTINCT
	                    A.MATRICULA,
	                    A.NOMBRE,
	                    A.PATERNO,
	                    A.MATERNO,
	                    A.EMAIL,
	                    G.CODIGOGRUPO,
	                    K.CLAVEASIGNATURA,
	                    A.ID_ESCUELA
                    FROM
	                    ALUMNOS_KARDEX K,
	                    ALUMNOS A,
	                    ALUMNOS_GRUPOS G,
	                    GRUPOS GR
                    WHERE
	                    A.NUMEROALUMNO    = K.NUMEROALUMNO AND
	                    A.NUMEROALUMNO    = G.NUMEROALUMNO AND
	                    G.PERIODO         = 1              AND 
	                    G.INICIAL         = 2013           AND 
	                    G.FINAL           = 2013           AND
	                    G.CODIGOGRUPO     = GR.CODIGOGRUPO AND
                            (GR.GRADO = 1 OR GR.GRADO = 4  )   AND
	                    G.CODIGOGRUPO LIKE 'S%'            AND 
	                    (K.CLAVEASIGNATURA = 'MPS0101' OR K.CLAVEASIGNATURA = 'MPEG0103' OR K.CLAVEASIGNATURA = 'MPEG0418' OR K.CLAVEASIGNATURA = 'MDER0101' OR K.CLAVEASIGNATURA = 'CRIM0103')      AND
	                    K.ID_EVAL         = 'A'            AND
	                    K.CALIFICACION_1  = 0              AND
	                    A.STATUS = 'A'                     AND
	                    A.ID_ESCUELA = 3 AND
	                    (A.MATRICULA LIKE '380%' OR A.MATRICULA LIKE '384%' OR A.MATRICULA LIKE '381%' OR A.MATRICULA LIKE '382%')
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
	                    G.CODIGOGRUPO,
	                    K.CLAVEASIGNATURA,
	                    A.ID_ESCUELA
                    FROM
	                    ALUMNOS_KARDEX K,
	                    ALUMNOS A,
	                    ALUMNOS_GRUPOS G,
	                    GRUPOS GR
                    WHERE
	                    A.NUMEROALUMNO    = K.NUMEROALUMNO AND
	                    A.NUMEROALUMNO    = G.NUMEROALUMNO AND
	                    G.PERIODO         = 1              AND 
	                    G.INICIAL         = 2013           AND 
	                    G.FINAL           = 2013           AND
	                    G.CODIGOGRUPO     = GR.CODIGOGRUPO AND
                            (GR.GRADO = 1 OR GR.GRADO = 4  )   AND
	                    G.CODIGOGRUPO LIKE 'S%'            AND 
	                    (K.CLAVEASIGNATURA = 'MPEG-103' OR K.CLAVEASIGNATURA = 'MPEG-418')      AND
	                    K.ID_EVAL         = 'A'            AND
	                    K.CALIFICACION_1  = 0              AND
	                    A.STATUS          = 'A'            AND
	                    A.ID_ESCUELA      = 4              AND
	                    (A.MATRICULA LIKE '480%' OR A.MATRICULA LIKE '484%' OR A.MATRICULA LIKE '481%' OR A.MATRICULA LIKE '482%')	
                    ";
        }
    }
}
