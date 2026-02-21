| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (AES-NI)       | 128B         |      21.99 ns |     0.111 ns |     0.104 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 128B         |     254.73 ns |     1.541 ns |     1.442 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128B         |     550.58 ns |     5.674 ns |     5.307 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128B         |     873.32 ns |     3.491 ns |     3.095 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (AES-NI)       | 128B         |     166.77 ns |     0.802 ns |     0.711 ns |         - |
| Encrypt · AES-256-CBC (OS)           | 128B         |     316.28 ns |     2.257 ns |     2.111 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 128B         |     493.66 ns |     4.228 ns |     3.955 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128B         |     793.99 ns |     4.748 ns |     4.441 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (AES-NI)       | 1KB          |      97.16 ns |     0.528 ns |     0.494 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 1KB          |     328.69 ns |     1.508 ns |     1.337 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 1KB          |   3,947.15 ns |    34.748 ns |    32.503 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,792.88 ns |    22.117 ns |    18.469 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 1KB          |     896.93 ns |     5.642 ns |     5.277 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 1KB          |   1,343.66 ns |     6.625 ns |     6.197 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 1KB          |   3,919.24 ns |    36.658 ns |    34.290 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,774.31 ns |    22.666 ns |    21.202 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (AES-NI)       | 8KB          |     717.34 ns |     2.572 ns |     2.280 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 8KB          |     935.56 ns |     2.260 ns |     2.003 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 8KB          |  31,023.05 ns |   217.926 ns |   193.185 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 8KB          |  35,893.18 ns |   173.002 ns |   161.827 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 8KB          |   5,918.69 ns |    46.203 ns |    40.958 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 8KB          |  10,744.38 ns |    63.355 ns |    59.262 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 8KB          |  31,336.32 ns |   472.852 ns |   442.307 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 8KB          |  36,403.27 ns |   262.589 ns |   245.626 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)           | 128KB        |  11,265.14 ns |    19.867 ns |    17.611 ns |     128 B |
| Decrypt · AES-256-CBC (AES-NI)       | 128KB        |  11,283.34 ns |    51.309 ns |    47.994 ns |         - |
| Decrypt · AES-256-CBC (Managed)      | 128KB        | 494,600.97 ns | 2,222.410 ns | 2,078.844 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128KB        | 570,849.06 ns | 2,836.616 ns | 2,653.373 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 128KB        |  92,021.41 ns |   657.829 ns |   615.333 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 128KB        | 169,948.47 ns | 1,056.066 ns |   987.844 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 128KB        | 502,627.63 ns | 4,759.660 ns | 4,452.189 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128KB        | 577,282.96 ns | 5,640.056 ns | 5,275.712 ns |    1024 B |