| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (AES-NI)       | 128B         |      34.88 ns |     0.091 ns |     0.081 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 128B         |     251.67 ns |     1.635 ns |     1.449 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128B         |     555.63 ns |     3.409 ns |     3.189 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128B         |     879.28 ns |     4.828 ns |     4.516 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (AES-NI)       | 128B         |     196.19 ns |     0.857 ns |     0.759 ns |         - |
| Encrypt · AES-256-CBC (OS)           | 128B         |     311.13 ns |     1.697 ns |     1.587 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 128B         |     561.94 ns |     3.284 ns |     3.071 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128B         |     791.98 ns |     5.975 ns |     5.589 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (AES-NI)       | 1KB          |     109.58 ns |     0.451 ns |     0.400 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 1KB          |     329.48 ns |     0.626 ns |     0.523 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 1KB          |   3,934.52 ns |    10.216 ns |     9.056 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,795.54 ns |    16.574 ns |    14.692 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 1KB          |     903.77 ns |     3.537 ns |     3.308 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 1KB          |   1,347.88 ns |     6.644 ns |     6.215 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 1KB          |   4,000.46 ns |    29.168 ns |    27.284 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,747.25 ns |    17.633 ns |    16.494 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (AES-NI)       | 8KB          |     709.38 ns |     4.531 ns |     4.238 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 8KB          |     939.84 ns |     1.744 ns |     1.546 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 8KB          |  30,856.03 ns |   105.914 ns |    82.691 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 8KB          |  36,057.01 ns |   342.150 ns |   320.048 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 8KB          |   5,918.35 ns |    33.719 ns |    31.541 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 8KB          |  10,595.50 ns |    51.341 ns |    48.025 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 8KB          |  31,308.13 ns |   304.560 ns |   284.886 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 8KB          |  36,366.53 ns |   284.769 ns |   252.440 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (AES-NI)       | 128KB        |  11,227.40 ns |    47.328 ns |    41.955 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 128KB        |  11,252.46 ns |    30.748 ns |    28.762 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128KB        | 496,567.17 ns | 2,924.653 ns | 2,735.722 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128KB        | 570,601.91 ns | 3,691.083 ns | 3,272.049 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 128KB        |  91,298.06 ns |   181.081 ns |   160.524 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 128KB        | 169,352.33 ns |   232.770 ns |   217.733 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 128KB        | 498,926.23 ns | 2,985.918 ns | 2,793.030 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128KB        | 574,323.46 ns | 2,775.502 ns | 2,596.207 ns |    1024 B |