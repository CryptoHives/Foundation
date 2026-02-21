| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (AES-NI)       | 128B         |      17.71 ns |     0.129 ns |     0.115 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 128B         |     244.54 ns |     1.570 ns |     1.391 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 128B         |     432.60 ns |     3.690 ns |     3.451 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128B         |     695.37 ns |     5.445 ns |     4.826 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (AES-NI)       | 128B         |     144.44 ns |     1.298 ns |     1.014 ns |         - |
| Encrypt · AES-128-CBC (OS)           | 128B         |     274.62 ns |     1.143 ns |     0.954 ns |     128 B |
| Encrypt · AES-128-CBC (Managed)      | 128B         |     386.31 ns |     4.470 ns |     4.181 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128B         |     630.12 ns |     6.938 ns |     6.490 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (AES-NI)       | 1KB          |      76.29 ns |     0.512 ns |     0.479 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 1KB          |     301.96 ns |     1.980 ns |     1.852 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 1KB          |   3,102.12 ns |    31.238 ns |    27.692 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,872.44 ns |    30.532 ns |    27.065 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 1KB          |     705.45 ns |     6.158 ns |     5.760 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 1KB          |   1,130.33 ns |     7.646 ns |     7.152 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 1KB          |   3,063.91 ns |    25.798 ns |    24.131 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,724.20 ns |    20.703 ns |    19.365 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (AES-NI)       | 8KB          |     559.46 ns |     4.613 ns |     4.090 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 8KB          |     731.92 ns |     3.072 ns |     2.873 ns |     128 B |
| Decrypt · AES-128-CBC (Managed)      | 8KB          |  24,423.88 ns |   177.443 ns |   165.980 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 8KB          |  29,132.40 ns |   190.094 ns |   177.814 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 8KB          |   4,274.77 ns |    58.412 ns |    54.639 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 8KB          |   8,967.49 ns |    31.782 ns |    26.539 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 8KB          |  24,551.95 ns |   166.417 ns |   155.667 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 8KB          |  28,402.16 ns |   225.807 ns |   211.220 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)           | 128KB        |   8,173.04 ns |    40.872 ns |    38.232 ns |     128 B |
| Decrypt · AES-128-CBC (AES-NI)       | 128KB        |   8,841.80 ns |    52.864 ns |    49.449 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 128KB        | 390,638.66 ns | 3,466.867 ns | 3,073.287 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128KB        | 462,620.07 ns | 3,789.361 ns | 3,544.571 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 128KB        |  66,133.84 ns |   514.823 ns |   481.565 ns |     128 B |
| Encrypt · AES-128-CBC (AES-NI)       | 128KB        | 145,261.75 ns | 1,165.131 ns | 1,089.864 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 128KB        | 390,755.12 ns | 2,541.536 ns | 2,253.006 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128KB        | 452,580.58 ns | 3,400.995 ns | 3,181.293 ns |     832 B |