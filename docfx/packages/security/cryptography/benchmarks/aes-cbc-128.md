| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CBC (OS)           | 128B         |     252.1 ns |     3.93 ns |     3.68 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 128B         |     448.1 ns |     6.41 ns |     6.00 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128B         |     791.6 ns |    15.60 ns |    17.34 ns |    1304 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (OS)           | 128B         |     281.4 ns |     2.23 ns |     1.97 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 128B         |     410.5 ns |     7.82 ns |     6.53 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128B         |     714.7 ns |     8.19 ns |     7.66 ns |    1288 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CBC (OS)           | 1KB          |     314.8 ns |     6.29 ns |     6.46 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 1KB          |   3,165.9 ns |    21.68 ns |    16.93 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 1KB          |   4,170.6 ns |    79.72 ns |    97.90 ns |    3096 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (OS)           | 1KB          |     710.0 ns |     5.05 ns |     4.72 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 1KB          |   3,157.0 ns |    23.75 ns |    21.05 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,948.9 ns |    54.51 ns |    48.32 ns |    3080 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CBC (OS)           | 8KB          |     733.3 ns |     2.87 ns |     2.40 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 8KB          |  25,418.6 ns |   501.18 ns |   468.81 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 8KB          |  30,069.0 ns |   215.08 ns |   190.66 ns |   17432 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (OS)           | 8KB          |   4,267.0 ns |    84.59 ns |    74.98 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 8KB          |  25,271.6 ns |   441.24 ns |   391.15 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 8KB          |  29,831.2 ns |   407.14 ns |   360.92 ns |   17416 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CBC (OS)           | 128KB        |   8,218.8 ns |    47.56 ns |    42.16 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 128KB        | 394,124.9 ns | 3,163.68 ns | 2,959.31 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128KB        | 532,080.2 ns | 2,572.09 ns | 2,147.81 ns |  263220 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (OS)           | 128KB        |  66,329.0 ns |   763.25 ns |   637.35 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 128KB        | 406,966.4 ns | 6,989.40 ns | 5,836.46 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128KB        | 526,372.8 ns | 5,896.85 ns | 5,227.40 ns |  263204 B |