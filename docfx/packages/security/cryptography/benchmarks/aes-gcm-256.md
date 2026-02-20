| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-GCM (AES-NI)       | 128B         |     106.12 ns |     0.373 ns |     0.348 ns |         - |
| Decrypt · AES-256-GCM (OS)           | 128B         |     123.94 ns |     0.585 ns |     0.547 ns |         - |
| Decrypt · AES-256-GCM (Managed)      | 128B         |     619.15 ns |     2.229 ns |     1.862 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 128B         |   1,110.87 ns |    20.438 ns |    21.869 ns |    1832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-GCM (AES-NI)       | 128B         |      75.11 ns |     0.387 ns |     0.362 ns |         - |
| Encrypt · AES-256-GCM (OS)           | 128B         |     125.12 ns |     0.323 ns |     0.286 ns |         - |
| Encrypt · AES-256-GCM (Managed)      | 128B         |     580.64 ns |     3.894 ns |     3.252 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 128B         |     997.36 ns |    16.484 ns |    13.765 ns |    1816 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)           | 1KB          |     217.50 ns |     0.686 ns |     0.642 ns |         - |
| Decrypt · AES-256-GCM (AES-NI)       | 1KB          |     295.48 ns |     0.741 ns |     0.579 ns |         - |
| Decrypt · AES-256-GCM (Managed)      | 1KB          |   4,030.31 ns |    10.531 ns |     9.851 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 1KB          |   4,830.85 ns |    23.490 ns |    20.824 ns |    1832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)           | 1KB          |     183.51 ns |     0.482 ns |     0.451 ns |         - |
| Encrypt · AES-256-GCM (AES-NI)       | 1KB          |     265.41 ns |     0.825 ns |     0.731 ns |         - |
| Encrypt · AES-256-GCM (Managed)      | 1KB          |   4,011.95 ns |    30.596 ns |    25.549 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 1KB          |   4,713.04 ns |    43.077 ns |    40.294 ns |    1816 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)           | 8KB          |   1,016.61 ns |     2.852 ns |     2.227 ns |         - |
| Decrypt · AES-256-GCM (AES-NI)       | 8KB          |   1,924.77 ns |     4.367 ns |     3.646 ns |         - |
| Decrypt · AES-256-GCM (Managed)      | 8KB          |  31,228.06 ns |    70.976 ns |    62.918 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 8KB          |  34,011.30 ns |    66.281 ns |    51.748 ns |    1832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)           | 8KB          |     725.56 ns |     2.304 ns |     2.043 ns |         - |
| Encrypt · AES-256-GCM (AES-NI)       | 8KB          |   1,846.45 ns |    24.372 ns |    22.798 ns |         - |
| Encrypt · AES-256-GCM (Managed)      | 8KB          |  31,457.20 ns |    78.088 ns |    73.044 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 8KB          |  34,084.10 ns |   127.584 ns |   113.100 ns |    1816 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-GCM (OS)           | 128KB        |  14,636.85 ns |    30.416 ns |    26.963 ns |         - |
| Decrypt · AES-256-GCM (AES-NI)       | 128KB        |  29,895.58 ns |    81.905 ns |    72.606 ns |         - |
| Decrypt · AES-256-GCM (Managed)      | 128KB        | 500,439.21 ns | 1,489.134 ns | 1,320.079 ns |         - |
| Decrypt · AES-256-GCM (BouncyCastle) | 128KB        | 538,457.02 ns | 1,758.658 ns | 1,645.049 ns |    1832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-GCM (OS)           | 128KB        |  10,807.78 ns |    55.941 ns |    49.590 ns |         - |
| Encrypt · AES-256-GCM (AES-NI)       | 128KB        |  28,740.88 ns |   463.177 ns |   433.256 ns |         - |
| Encrypt · AES-256-GCM (Managed)      | 128KB        | 500,431.79 ns | 1,409.197 ns | 1,249.216 ns |         - |
| Encrypt · AES-256-GCM (BouncyCastle) | 128KB        | 535,804.20 ns | 1,152.689 ns |   962.547 ns |    1816 B |