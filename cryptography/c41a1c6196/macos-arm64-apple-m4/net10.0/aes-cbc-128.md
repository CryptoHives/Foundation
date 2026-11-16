| Description                                 | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      23.48 ns |     0.164 ns |     0.153 ns |      23.42 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 128B         |     196.64 ns |     1.247 ns |     1.167 ns |     196.79 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     349.61 ns |     1.781 ns |     1.391 ns |     349.31 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128B         |     617.34 ns |     4.408 ns |     3.441 ns |     616.64 ns |     832 B |
|                                             |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128B         |      38.40 ns |     0.754 ns |     0.898 ns |      38.05 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 128B         |     201.29 ns |     0.696 ns |     0.617 ns |     201.25 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128B         |     432.70 ns |     1.065 ns |     0.996 ns |     432.94 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128B         |     567.29 ns |     1.864 ns |     1.744 ns |     567.77 ns |     832 B |
|                                             |              |               |              |              |               |           |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |      90.47 ns |     0.639 ns |     0.598 ns |      90.32 ns |         - |
| Decrypt · AES-128-CBC (OS)                  | 1KB          |     241.28 ns |     4.829 ns |     6.447 ns |     238.59 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   2,408.89 ns |    19.869 ns |    15.512 ns |   2,405.31 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,420.97 ns |    26.125 ns |    21.815 ns |   3,413.35 ns |     832 B |
|                                             |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 1KB          |     348.29 ns |     0.811 ns |     0.758 ns |     348.46 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 1KB          |     559.36 ns |     1.823 ns |     1.705 ns |     559.73 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 1KB          |   3,108.01 ns |    10.485 ns |     9.808 ns |   3,108.28 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 1KB          |   3,303.47 ns |    10.085 ns |     9.433 ns |   3,305.05 ns |     832 B |
|                                             |              |               |              |              |               |           |
| Decrypt · AES-128-CBC (OS)                  | 8KB          |     593.70 ns |     3.325 ns |     2.948 ns |     592.15 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |     635.31 ns |     3.903 ns |     3.259 ns |     634.59 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  18,878.03 ns |    62.007 ns |    54.967 ns |  18,868.70 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  26,342.08 ns |   520.844 ns |   952.393 ns |  25,862.55 ns |     832 B |
|                                             |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 8KB          |   3,141.31 ns |     2.915 ns |     2.434 ns |   3,142.07 ns |         - |
| Encrypt · AES-128-CBC (OS)                  | 8KB          |   3,347.19 ns |    12.107 ns |    11.325 ns |   3,347.59 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 8KB          |  24,540.77 ns |    74.694 ns |    69.868 ns |  24,559.69 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 8KB          |  25,292.19 ns |    72.938 ns |    60.907 ns |  25,268.36 ns |     832 B |
|                                             |              |               |              |              |               |           |
| Decrypt · AES-128-CBC (OS)                  | 128KB        |   6,763.79 ns |    25.527 ns |    21.316 ns |   6,759.52 ns |      72 B |
| Decrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |   9,911.45 ns |    18.676 ns |    17.469 ns |   9,913.16 ns |         - |
| Decrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 303,025.15 ns | 5,289.722 ns | 4,417.157 ns | 300,224.98 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 409,141.56 ns | 2,062.049 ns | 1,721.904 ns | 409,306.36 ns |     832 B |
|                                             |              |               |              |              |               |           |
| Encrypt · AES-128-CBC (OS)                  | 128KB        |  51,378.04 ns |   101.147 ns |    89.664 ns |  51,399.26 ns |      72 B |
| Encrypt · AES-128-CBC (CryptoHives-ARM-AES) | 128KB        |  51,502.78 ns |   213.910 ns |   167.007 ns |  51,563.98 ns |         - |
| Encrypt · AES-128-CBC (CryptoHives-Scalar)  | 128KB        | 390,471.66 ns | 1,280.138 ns | 1,134.809 ns | 389,929.16 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle)        | 128KB        | 403,399.01 ns | 6,049.174 ns | 5,051.334 ns | 401,700.46 ns |     832 B |