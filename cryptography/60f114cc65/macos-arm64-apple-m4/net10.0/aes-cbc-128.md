| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-128-CBC (ArmAes)       | 128B         |      22.61 ns |     0.030 ns |     0.028 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 128B         |     192.55 ns |     0.809 ns |     0.757 ns |      72 B |
| Decrypt · AES-128-CBC (Managed)      | 128B         |     386.19 ns |     0.156 ns |     0.145 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128B         |     613.57 ns |     0.447 ns |     0.418 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (ArmAes)       | 128B         |     136.72 ns |     0.735 ns |     0.574 ns |         - |
| Encrypt · AES-128-CBC (OS)           | 128B         |     200.16 ns |     0.404 ns |     0.337 ns |      72 B |
| Encrypt · AES-128-CBC (Managed)      | 128B         |     436.19 ns |     0.107 ns |     0.083 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128B         |     574.94 ns |     0.404 ns |     0.337 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (ArmAes)       | 1KB          |      89.27 ns |     0.061 ns |     0.057 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 1KB          |     232.21 ns |     0.588 ns |     0.459 ns |      72 B |
| Decrypt · AES-128-CBC (Managed)      | 1KB          |   2,704.31 ns |     0.426 ns |     0.398 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,392.08 ns |     3.389 ns |     3.170 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 1KB          |     562.04 ns |     3.204 ns |     2.997 ns |      72 B |
| Encrypt · AES-128-CBC (ArmAes)       | 1KB          |     951.95 ns |     4.201 ns |     3.930 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 1KB          |   3,133.37 ns |     0.533 ns |     0.498 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,266.44 ns |     0.850 ns |     0.753 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)           | 8KB          |     587.54 ns |     4.079 ns |     3.815 ns |      72 B |
| Decrypt · AES-128-CBC (ArmAes)       | 8KB          |     630.51 ns |     0.562 ns |     0.526 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 8KB          |  21,251.00 ns |     6.404 ns |     5.990 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 8KB          |  25,355.22 ns |    89.966 ns |    79.752 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 8KB          |   3,279.37 ns |     8.334 ns |     7.388 ns |      72 B |
| Encrypt · AES-128-CBC (ArmAes)       | 8KB          |   7,414.01 ns |    16.366 ns |    14.508 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 8KB          |  24,690.51 ns |    13.759 ns |    12.197 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 8KB          |  24,753.07 ns |     5.387 ns |     5.039 ns |     832 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-128-CBC (OS)           | 128KB        |   6,697.23 ns |    20.570 ns |    19.241 ns |      72 B |
| Decrypt · AES-128-CBC (ArmAes)       | 128KB        |   9,848.31 ns |     4.203 ns |     3.931 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 128KB        | 341,001.87 ns |   156.938 ns |   139.122 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128KB        | 402,612.07 ns | 1,389.455 ns | 1,299.697 ns |     832 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-128-CBC (OS)           | 128KB        |  50,720.54 ns |   181.700 ns |   161.072 ns |      72 B |
| Encrypt · AES-128-CBC (ArmAes)       | 128KB        | 123,629.75 ns |   305.106 ns |   254.777 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 128KB        | 394,477.60 ns |   153.083 ns |   135.704 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128KB        | 395,609.25 ns |    81.615 ns |    76.343 ns |     832 B |