| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (ArmAes)       | 128B         |      24.49 ns |     0.058 ns |     0.054 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 128B         |     223.79 ns |     2.652 ns |     2.481 ns |      72 B |
| Decrypt · AES-256-CBC (Managed)      | 128B         |     518.96 ns |     0.478 ns |     0.447 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128B         |     795.90 ns |     0.699 ns |     0.584 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (ArmAes)       | 128B         |     147.67 ns |     0.518 ns |     0.484 ns |         - |
| Encrypt · AES-256-CBC (OS)           | 128B         |     244.19 ns |     1.642 ns |     1.536 ns |      72 B |
| Encrypt · AES-256-CBC (Managed)      | 128B         |     568.90 ns |     0.157 ns |     0.140 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128B         |     727.30 ns |     3.226 ns |     3.018 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (ArmAes)       | 1KB          |     105.71 ns |     0.536 ns |     0.501 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 1KB          |     278.84 ns |     1.092 ns |     1.022 ns |      72 B |
| Decrypt · AES-256-CBC (Managed)      | 1KB          |   3,658.68 ns |     1.154 ns |     0.963 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,423.07 ns |     2.201 ns |     1.951 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 1KB          |     726.35 ns |     1.198 ns |     1.121 ns |      72 B |
| Encrypt · AES-256-CBC (ArmAes)       | 1KB          |   1,089.55 ns |     3.812 ns |     3.379 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 1KB          |   4,093.74 ns |     2.524 ns |     2.361 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,264.13 ns |     4.516 ns |     3.771 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)           | 8KB          |     713.66 ns |     3.539 ns |     3.137 ns |      72 B |
| Decrypt · AES-256-CBC (ArmAes)       | 8KB          |     750.17 ns |     2.570 ns |     2.404 ns |         - |
| Decrypt · AES-256-CBC (Managed)      | 8KB          |  28,820.45 ns |     3.599 ns |     3.005 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 8KB          |  33,282.54 ns |    35.367 ns |    31.352 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 8KB          |   4,420.51 ns |     3.907 ns |     3.463 ns |      72 B |
| Encrypt · AES-256-CBC (ArmAes)       | 8KB          |   8,531.38 ns |    45.876 ns |    42.912 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 8KB          |  32,252.99 ns |    15.854 ns |    14.830 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 8KB          |  32,451.74 ns |    19.617 ns |    18.350 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)           | 128KB        |   8,453.37 ns |    31.046 ns |    29.040 ns |      72 B |
| Decrypt · AES-256-CBC (ArmAes)       | 128KB        |  11,843.55 ns |    24.484 ns |    22.902 ns |         - |
| Decrypt · AES-256-CBC (Managed)      | 128KB        | 461,650.22 ns |   193.805 ns |   171.803 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128KB        | 527,391.86 ns | 2,011.466 ns | 1,881.527 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 128KB        |  68,785.66 ns |    68.572 ns |    60.787 ns |      72 B |
| Encrypt · AES-256-CBC (ArmAes)       | 128KB        | 136,660.36 ns |   528.923 ns |   494.755 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 128KB        | 515,053.11 ns |   540.111 ns |   505.221 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128KB        | 518,864.32 ns |   247.465 ns |   231.479 ns |    1024 B |