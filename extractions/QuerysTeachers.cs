using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace univer.extractions
{
    public static class QuerysTeachers
    {

        static public string salud()
        {
            return @"
                         SELECT 
                          B.CLAVEPROFESOR, B.NOMBREPROFESOR, B.EMAIL, A.CODIGOGRUPO, A.CLAVEASIGNATURA
                        FROM
                          HORARIOS_DET A,
                          PROFESORES B
                        WHERE
                          A.CLAVEPROFESOR = B.CLAVEPROFESOR   AND
                          A.INICIAL = 2013                    AND
                          A.FINAL   = 2013					  AND
                          A.PERIODO = 1						  AND
                          A.ID_ESCUELA = 5                    AND
                          A.CLAVEASIGNATURA = 'MPS0101'       AND
                          A.CODIGOGRUPO  LIKE 'S%'            AND
                          A.CLAVEPROFESOR <> ''

                          GROUP BY
                           B.CLAVEPROFESOR, B.NOMBREPROFESOR, B.EMAIL, A.CODIGOGRUPO, A.CLAVEASIGNATURA
                    ";
        }

        static public string rayon() 
        {
            return @"  
                    SELECT 
                      B.CLAVEPROFESOR, B.NOMBREPROFESOR, B.EMAIL, A.CODIGOGRUPO, A.CLAVEASIGNATURA
                    FROM
                      HORARIOS_DET A,
                      PROFESORES B
                    WHERE
                      A.CLAVEPROFESOR = B.CLAVEPROFESOR   AND
                      A.INICIAL = 2013                    AND
                      A.FINAL   = 2013					  AND
                      A.PERIODO = 1						  AND
                      A.ID_ESCUELA = 1                    AND
                      (A.CLAVEASIGNATURA = 'MDER0101'       OR A.CLAVEASIGNATURA = 'CRIM0103') AND
                      A.CODIGOGRUPO  LIKE 'S%'            AND
                      A.CLAVEPROFESOR <> ''

                      GROUP BY
                       B.CLAVEPROFESOR, B.NOMBREPROFESOR, B.EMAIL, A.CODIGOGRUPO, A.CLAVEASIGNATURA";
        }

        static public string neza() 
        {
            return @"SELECT 
                      B.CLAVEPROFESOR, B.NOMBREPROFESOR, B.EMAIL, A.CODIGOGRUPO, A.CLAVEASIGNATURA
                    FROM
                      HORARIOS_DET A,
                      PROFESORES B
                    WHERE
                      A.CLAVEPROFESOR = B.CLAVEPROFESOR   AND
                      A.INICIAL = 2013                    AND
                      A.FINAL   = 2013					  AND
                      A.PERIODO = 1						  AND
                      A.ID_ESCUELA = 2                    AND
                      (A.CLAVEASIGNATURA = 'MPS0101'       OR A.CLAVEASIGNATURA = 'MPEG0103' OR A.CLAVEASIGNATURA = 'MPEG0418' OR A.CLAVEASIGNATURA = 'MDER0101' OR A.CLAVEASIGNATURA = 'CRIM0103') AND
                      A.CODIGOGRUPO  LIKE 'S%'            AND
                      A.CLAVEPROFESOR <> ''

                      GROUP BY
                       B.CLAVEPROFESOR, B.NOMBREPROFESOR, B.EMAIL, A.CODIGOGRUPO, A.CLAVEASIGNATURA";
        }

        static public string ixtapaluca() 
        {
            return @"SELECT 
                      B.CLAVEPROFESOR, B.NOMBREPROFESOR, B.EMAIL, A.CODIGOGRUPO, A.CLAVEASIGNATURA
                    FROM
                      HORARIOS_DET A,
                      PROFESORES B
                    WHERE
                      A.CLAVEPROFESOR = B.CLAVEPROFESOR   AND
                      A.INICIAL = 2013                    AND
                      A.FINAL   = 2013					  AND
                      A.PERIODO = 1						  AND
                      A.ID_ESCUELA = 3                    AND
                      (A.CLAVEASIGNATURA = 'MPS0101'       OR A.CLAVEASIGNATURA = 'MPEG0103' OR A.CLAVEASIGNATURA = 'MPEG0418' OR A.CLAVEASIGNATURA = 'MDER0101' OR A.CLAVEASIGNATURA = 'CRIM0103') AND
                      A.CODIGOGRUPO  LIKE 'S%'            AND
                      A.CLAVEPROFESOR <> ''

                      GROUP BY
                       B.CLAVEPROFESOR, B.NOMBREPROFESOR, B.EMAIL, A.CODIGOGRUPO, A.CLAVEASIGNATURA";
        }

        static public string hidalgo() 
        {
            return @"SELECT 
                      B.CLAVEPROFESOR, B.NOMBREPROFESOR, B.EMAIL, A.CODIGOGRUPO, A.CLAVEASIGNATURA
                    FROM
                      HORARIOS_DET A,
                      PROFESORES B
                    WHERE
                      A.CLAVEPROFESOR = B.CLAVEPROFESOR   AND
                      A.INICIAL = 2013                    AND
                      A.FINAL   = 2013					  AND
                      A.PERIODO = 1						  AND
                      A.ID_ESCUELA = 4                    AND
                      (A.CLAVEASIGNATURA = 'MPEG-103'       OR A.CLAVEASIGNATURA = 'MPEG-418') AND
                      A.CODIGOGRUPO  LIKE 'S%'            AND
                      A.CLAVEPROFESOR <> ''

                      GROUP BY
                       B.CLAVEPROFESOR, B.NOMBREPROFESOR, B.EMAIL, A.CODIGOGRUPO, A.CLAVEASIGNATURA";
        }

    }
}
