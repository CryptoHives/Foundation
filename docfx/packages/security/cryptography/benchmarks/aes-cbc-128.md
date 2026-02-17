| Description                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CBC (OS)           | 128B         |     248.8 ns |     1.44 ns |     1.35 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 128B         |     438.2 ns |     2.69 ns |     2.39 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128B         |     694.3 ns |     4.26 ns |     3.98 ns |     832 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (OS)           | 128B         |     281.5 ns |     3.56 ns |     3.33 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 128B         |     402.6 ns |     4.11 ns |     3.65 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128B         |     631.0 ns |     7.62 ns |     7.12 ns |     832 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CBC (OS)           | 1KB          |     298.4 ns |     2.67 ns |     2.49 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 1KB          |   3,109.7 ns |    16.63 ns |    12.98 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,870.0 ns |    27.34 ns |    24.24 ns |     832 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (OS)           | 1KB          |     702.4 ns |     2.50 ns |     2.34 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 1KB          |   3,133.5 ns |    22.85 ns |    21.37 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,765.5 ns |    16.79 ns |    14.88 ns |     832 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CBC (OS)           | 8KB          |     739.9 ns |     2.80 ns |     2.62 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 8KB          |  24,572.5 ns |   165.80 ns |   155.09 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 8KB          |  28,916.9 ns |   113.90 ns |    95.11 ns |     832 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (OS)           | 8KB          |   4,262.7 ns |    44.02 ns |    39.02 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 8KB          |  24,943.5 ns |   159.80 ns |   149.48 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 8KB          |  28,368.9 ns |   155.81 ns |   138.12 ns |     832 B |
|                                      |              |              |             |             |           |
| Decrypt · AES-128-CBC (OS)           | 128KB        |   8,214.7 ns |    38.96 ns |    36.45 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 128KB        | 392,156.9 ns | 2,984.23 ns | 2,791.45 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128KB        | 461,901.6 ns | 1,677.01 ns | 1,568.68 ns |     832 B |
|                                      |              |              |             |             |           |
| Encrypt · AES-128-CBC (OS)           | 128KB        |  65,837.8 ns |   304.64 ns |   284.96 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 128KB        | 399,105.8 ns | 2,965.92 ns | 2,774.32 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128KB        | 451,310.5 ns | 3,689.54 ns | 3,451.20 ns |     832 B |