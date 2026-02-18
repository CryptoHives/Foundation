| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CBC (AES-NI)       | 128B         |     133.7 ns |     1.20 ns |     1.12 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 128B         |     250.5 ns |     1.08 ns |     0.95 ns |     128 B |
| Decrypt · AES-256-CBC (Managed)      | 128B         |     553.2 ns |     2.07 ns |     1.73 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128B         |     869.8 ns |     5.76 ns |     5.39 ns |    1024 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (AES-NI)       | 128B         |     185.3 ns |     0.42 ns |     0.35 ns |         - |
| Encrypt · AES-256-CBC (OS)           | 128B         |     314.6 ns |     1.48 ns |     1.31 ns |     128 B |
| Encrypt · AES-256-CBC (Managed)      | 128B         |     502.2 ns |     3.36 ns |     3.14 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128B         |     786.1 ns |     3.83 ns |     3.58 ns |    1024 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-CBC (OS)           | 1KB          |     326.2 ns |     0.53 ns |     0.44 ns |     128 B |
| Decrypt · AES-256-CBC (AES-NI)       | 1KB          |     874.5 ns |     4.11 ns |     3.84 ns |         - |
| Decrypt · AES-256-CBC (Managed)      | 1KB          |   3,964.6 ns |    26.99 ns |    25.25 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,764.0 ns |    20.00 ns |    17.73 ns |    1024 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (OS)           | 1KB          |     893.7 ns |     3.02 ns |     2.83 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 1KB          |   1,438.5 ns |     2.25 ns |     2.11 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 1KB          |   3,941.4 ns |    37.24 ns |    34.83 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,718.9 ns |    13.89 ns |    12.99 ns |    1024 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-CBC (OS)           | 8KB          |     936.3 ns |     2.57 ns |     2.28 ns |     128 B |
| Decrypt · AES-256-CBC (AES-NI)       | 8KB          |   6,852.1 ns |    35.49 ns |    33.20 ns |         - |
| Decrypt · AES-256-CBC (Managed)      | 8KB          |  30,925.6 ns |   165.66 ns |   138.33 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 8KB          |  35,734.3 ns |   190.73 ns |   159.27 ns |    1024 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (OS)           | 8KB          |   5,896.6 ns |    20.04 ns |    18.74 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 8KB          |  11,505.4 ns |    24.87 ns |    23.27 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 8KB          |  31,523.6 ns |   144.79 ns |   128.36 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 8KB          |  36,236.5 ns |   279.73 ns |   261.66 ns |    1024 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-256-CBC (OS)           | 128KB        |  11,245.4 ns |    20.45 ns |    18.13 ns |     128 B |
| Decrypt · AES-256-CBC (AES-NI)       | 128KB        | 110,547.7 ns |   590.41 ns |   552.27 ns |         - |
| Decrypt · AES-256-CBC (Managed)      | 128KB        | 495,874.5 ns | 3,471.22 ns | 3,246.98 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128KB        | 568,248.7 ns | 6,357.73 ns | 5,308.99 ns |    1024 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-256-CBC (OS)           | 128KB        |  91,142.1 ns |   310.98 ns |   275.67 ns |     128 B |
| Encrypt · AES-256-CBC (AES-NI)       | 128KB        | 184,019.1 ns |   259.73 ns |   242.95 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 128KB        | 504,766.2 ns | 2,554.16 ns | 2,264.20 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128KB        | 573,755.6 ns | 3,938.12 ns | 3,683.72 ns |    1024 B |