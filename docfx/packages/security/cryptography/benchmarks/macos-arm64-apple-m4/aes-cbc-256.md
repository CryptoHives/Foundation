| Description                          | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (ArmAes)       | 128B         |      24.92 ns |     0.058 ns |     0.048 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 128B         |     233.15 ns |     1.106 ns |     1.035 ns |      72 B |
| Decrypt · AES-256-CBC (Managed)      | 128B         |     518.53 ns |     0.243 ns |     0.227 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128B         |     795.30 ns |     0.400 ns |     0.354 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (ArmAes)       | 128B         |     153.83 ns |     0.917 ns |     0.766 ns |         - |
| Encrypt · AES-256-CBC (OS)           | 128B         |     251.55 ns |     1.324 ns |     1.106 ns |      72 B |
| Encrypt · AES-256-CBC (Managed)      | 128B         |     569.49 ns |     0.149 ns |     0.139 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128B         |     736.86 ns |     0.196 ns |     0.183 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (ArmAes)       | 1KB          |     108.25 ns |     0.202 ns |     0.169 ns |         - |
| Decrypt · AES-256-CBC (OS)           | 1KB          |     282.01 ns |     2.077 ns |     1.943 ns |      72 B |
| Decrypt · AES-256-CBC (Managed)      | 1KB          |   3,663.70 ns |     1.186 ns |     0.926 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,430.18 ns |     1.922 ns |     1.798 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 1KB          |     763.01 ns |     2.050 ns |     1.917 ns |      72 B |
| Encrypt · AES-256-CBC (ArmAes)       | 1KB          |   1,146.81 ns |     3.669 ns |     3.432 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 1KB          |   4,096.15 ns |     0.632 ns |     0.591 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 1KB          |   4,274.08 ns |     1.535 ns |     1.198 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)           | 8KB          |     756.04 ns |     2.310 ns |     2.161 ns |      72 B |
| Decrypt · AES-256-CBC (ArmAes)       | 8KB          |     767.55 ns |     1.510 ns |     1.339 ns |         - |
| Decrypt · AES-256-CBC (Managed)      | 8KB          |  28,840.17 ns |     3.348 ns |     3.132 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 8KB          |  33,347.77 ns |    32.424 ns |    30.330 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 8KB          |   4,510.21 ns |    33.528 ns |    31.362 ns |      72 B |
| Encrypt · AES-256-CBC (ArmAes)       | 8KB          |   9,077.79 ns |    34.072 ns |    31.871 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 8KB          |  32,295.66 ns |    55.381 ns |    46.246 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 8KB          |  32,428.93 ns |    17.914 ns |    15.880 ns |    1024 B |
|                                      |              |               |              |              |           |
| Decrypt · AES-256-CBC (OS)           | 128KB        |   8,829.43 ns |    64.798 ns |    50.590 ns |      72 B |
| Decrypt · AES-256-CBC (ArmAes)       | 128KB        |  12,084.83 ns |     1.457 ns |     1.363 ns |         - |
| Decrypt · AES-256-CBC (Managed)      | 128KB        | 462,118.11 ns |   113.985 ns |   106.621 ns |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128KB        | 528,189.55 ns | 1,732.732 ns | 1,620.799 ns |    1024 B |
|                                      |              |               |              |              |           |
| Encrypt · AES-256-CBC (OS)           | 128KB        |  69,527.15 ns |   496.926 ns |   464.824 ns |      72 B |
| Encrypt · AES-256-CBC (ArmAes)       | 128KB        | 143,957.33 ns |   411.789 ns |   385.188 ns |         - |
| Encrypt · AES-256-CBC (Managed)      | 128KB        | 515,731.27 ns |   397.243 ns |   310.141 ns |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128KB        | 519,613.65 ns |   176.324 ns |   147.238 ns |    1024 B |