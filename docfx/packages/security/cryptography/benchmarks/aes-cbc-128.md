| Description                          | TestDataSize | Mean           | Error         | StdDev         | Median         | Allocated |
|------------------------------------- |------------- |---------------:|--------------:|---------------:|---------------:|----------:|
| Decrypt · AES-128-CBC (Managed)      | 128B         |       943.6 ns |      76.85 ns |       219.3 ns |       900.0 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128B         |     6,309.1 ns |     384.22 ns |     1,126.9 ns |     6,000.0 ns |    1304 B |
| Decrypt · AES-128-CBC (OS)           | 128B         |     7,447.5 ns |     943.75 ns |     2,767.9 ns |     7,100.0 ns |    1104 B |
|                                      |              |                |               |                |                |           |
| Encrypt · AES-128-CBC (Managed)      | 128B         |     1,004.0 ns |      79.64 ns |       234.8 ns |     1,000.0 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128B         |     5,719.8 ns |     359.90 ns |     1,038.4 ns |     5,550.0 ns |    1288 B |
| Encrypt · AES-128-CBC (OS)           | 128B         |     6,489.8 ns |     900.25 ns |     2,626.1 ns |     5,800.0 ns |    1088 B |
|                                      |              |                |               |                |                |           |
| Decrypt · AES-128-CBC (Managed)      | 1KB          |     4,348.0 ns |     185.29 ns |       546.3 ns |     4,100.0 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 1KB          |     7,525.5 ns |   1,026.32 ns |     2,993.8 ns |     6,750.0 ns |    2896 B |
| Decrypt · AES-128-CBC (BouncyCastle) | 1KB          |    26,412.6 ns |     959.53 ns |     2,753.1 ns |    25,400.0 ns |    3096 B |
|                                      |              |                |               |                |                |           |
| Encrypt · AES-128-CBC (Managed)      | 1KB          |     4,394.7 ns |     172.13 ns |       493.9 ns |     4,200.0 ns |         - |
| Encrypt · AES-128-CBC (OS)           | 1KB          |     6,220.6 ns |     764.05 ns |     2,216.6 ns |     5,800.0 ns |    2880 B |
| Encrypt · AES-128-CBC (BouncyCastle) | 1KB          |    25,460.0 ns |     600.40 ns |     1,623.2 ns |    25,100.0 ns |    3080 B |
|                                      |              |                |               |                |                |           |
| Decrypt · AES-128-CBC (OS)           | 8KB          |     9,023.2 ns |   1,045.19 ns |     3,065.4 ns |     8,700.0 ns |   17232 B |
| Decrypt · AES-128-CBC (Managed)      | 8KB          |    32,940.2 ns |   1,271.65 ns |     3,689.3 ns |    31,300.0 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 8KB          |   175,166.7 ns |     989.63 ns |       772.6 ns |   175,050.0 ns |   17432 B |
|                                      |              |                |               |                |                |           |
| Encrypt · AES-128-CBC (OS)           | 8KB          |    11,486.6 ns |     912.41 ns |     2,647.1 ns |    11,300.0 ns |   17216 B |
| Encrypt · AES-128-CBC (Managed)      | 8KB          |    33,627.6 ns |   1,355.75 ns |     3,954.8 ns |    31,650.0 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 8KB          |   176,692.3 ns |   2,740.05 ns |     5,658.7 ns |   175,350.0 ns |   17416 B |
|                                      |              |                |               |                |                |           |
| Decrypt · AES-128-CBC (OS)           | 128KB        |    35,836.1 ns |   1,802.71 ns |     5,230.0 ns |    34,400.0 ns |  262992 B |
| Decrypt · AES-128-CBC (Managed)      | 128KB        |   454,238.1 ns |  17,569.27 ns |    50,971.6 ns |   437,700.0 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128KB        | 2,143,658.0 ns | 365,494.55 ns | 1,077,669.0 ns | 2,602,300.0 ns |  263192 B |
|                                      |              |                |               |                |                |           |
| Encrypt · AES-128-CBC (OS)           | 128KB        |    90,388.7 ns |   3,715.20 ns |    10,778.5 ns |    84,500.0 ns |  262976 B |
| Encrypt · AES-128-CBC (Managed)      | 128KB        |   457,865.2 ns |  18,399.08 ns |    53,961.3 ns |   471,650.0 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128KB        | 2,128,915.0 ns | 395,070.65 ns | 1,164,874.8 ns | 2,668,800.0 ns |  263176 B |