| Description                          | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| Decrypt · AES-128-CBC (ArmAes)       | 128B         |      22.08 ns |   0.068 ns |   0.061 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 128B         |     187.81 ns |   1.061 ns |   0.828 ns |      72 B |
| Decrypt · AES-128-CBC (Managed)      | 128B         |     386.28 ns |   0.583 ns |   0.545 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128B         |     604.78 ns |   1.863 ns |   1.652 ns |     832 B |
|                                      |              |               |            |            |           |
| Encrypt · AES-128-CBC (ArmAes)       | 128B         |     129.02 ns |   0.636 ns |   0.564 ns |         - |
| Encrypt · AES-128-CBC (OS)           | 128B         |     192.84 ns |   1.322 ns |   1.104 ns |      72 B |
| Encrypt · AES-128-CBC (Managed)      | 128B         |     428.98 ns |   0.876 ns |   0.777 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128B         |     558.80 ns |   3.133 ns |   2.931 ns |     832 B |
|                                      |              |               |            |            |           |
| Decrypt · AES-128-CBC (ArmAes)       | 1KB          |      87.13 ns |   0.535 ns |   0.500 ns |         - |
| Decrypt · AES-128-CBC (OS)           | 1KB          |     229.65 ns |   2.508 ns |   2.346 ns |      72 B |
| Decrypt · AES-128-CBC (Managed)      | 1KB          |   2,702.80 ns |   1.275 ns |   1.193 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,378.77 ns |   3.735 ns |   3.494 ns |     832 B |
|                                      |              |               |            |            |           |
| Encrypt · AES-128-CBC (OS)           | 1KB          |     541.56 ns |   1.345 ns |   1.192 ns |      72 B |
| Encrypt · AES-128-CBC (ArmAes)       | 1KB          |     914.69 ns |   5.226 ns |   4.888 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 1KB          |   3,112.53 ns |   6.331 ns |   5.922 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 1KB          |   3,241.94 ns |   3.052 ns |   2.549 ns |     832 B |
|                                      |              |               |            |            |           |
| Decrypt · AES-128-CBC (OS)           | 8KB          |     560.77 ns |   4.027 ns |   3.767 ns |      72 B |
| Decrypt · AES-128-CBC (ArmAes)       | 8KB          |     610.05 ns |   3.382 ns |   3.164 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 8KB          |  21,239.52 ns |   7.107 ns |   6.648 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 8KB          |  25,311.13 ns |  45.050 ns |  42.140 ns |     832 B |
|                                      |              |               |            |            |           |
| Encrypt · AES-128-CBC (OS)           | 8KB          |   3,286.63 ns |  25.573 ns |  22.669 ns |      72 B |
| Encrypt · AES-128-CBC (ArmAes)       | 8KB          |   7,177.20 ns |  18.455 ns |  16.360 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 8KB          |  24,539.18 ns |  25.378 ns |  21.192 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 8KB          |  24,691.65 ns |  18.235 ns |  17.057 ns |     832 B |
|                                      |              |               |            |            |           |
| Decrypt · AES-128-CBC (OS)           | 128KB        |   6,436.87 ns |  25.556 ns |  23.905 ns |      72 B |
| Decrypt · AES-128-CBC (ArmAes)       | 128KB        |   9,613.76 ns |  33.784 ns |  31.601 ns |         - |
| Decrypt · AES-128-CBC (Managed)      | 128KB        | 341,935.68 ns | 504.550 ns | 471.956 ns |         - |
| Decrypt · AES-128-CBC (BouncyCastle) | 128KB        | 402,159.16 ns | 961.030 ns | 898.948 ns |     832 B |
|                                      |              |               |            |            |           |
| Encrypt · AES-128-CBC (OS)           | 128KB        |  50,556.34 ns |  34.506 ns |  30.589 ns |      72 B |
| Encrypt · AES-128-CBC (ArmAes)       | 128KB        | 119,683.72 ns | 506.758 ns | 395.644 ns |         - |
| Encrypt · AES-128-CBC (Managed)      | 128KB        | 393,501.61 ns | 265.260 ns | 221.504 ns |         - |
| Encrypt · AES-128-CBC (BouncyCastle) | 128KB        | 393,912.18 ns | 499.123 ns | 466.880 ns |     832 B |