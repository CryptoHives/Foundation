| Description                          | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · AES-128-CCM (ArmAes)       | 128B         |     273.4 ns |   1.13 ns |   1.05 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128B         |     957.4 ns |   0.69 ns |   0.65 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,427.7 ns |   2.83 ns |   2.65 ns |    2424 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-128-CCM (ArmAes)       | 128B         |     238.9 ns |   1.22 ns |   1.14 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128B         |     912.3 ns |   0.48 ns |   0.40 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128B         |   1,384.6 ns |   3.04 ns |   2.85 ns |    2464 B |
|                                      |              |              |           |           |           |
| Decrypt · AES-128-CCM (ArmAes)       | 1KB          |   1,538.2 ns |   3.70 ns |   3.46 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 1KB          |   5,995.5 ns |   2.76 ns |   2.58 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 1KB          |   6,843.3 ns |  18.32 ns |  17.14 ns |    2424 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-128-CCM (ArmAes)       | 1KB          |   1,502.6 ns |   3.89 ns |   3.64 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 1KB          |   5,953.0 ns |   1.37 ns |   1.28 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 1KB          |   6,744.4 ns |  11.18 ns |  10.46 ns |    2464 B |
|                                      |              |              |           |           |           |
| Decrypt · AES-128-CCM (ArmAes)       | 8KB          |  11,687.0 ns |  36.11 ns |  33.78 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 8KB          |  46,739.8 ns | 396.13 ns | 370.54 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 8KB          |  49,745.9 ns |  87.41 ns |  81.76 ns |    2424 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-128-CCM (ArmAes)       | 8KB          |  11,540.1 ns |  33.28 ns |  31.13 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 8KB          |  46,157.0 ns |  39.38 ns |  32.89 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 8KB          |  49,590.7 ns | 112.17 ns |  99.44 ns |    2464 B |
|                                      |              |              |           |           |           |
| Decrypt · AES-128-CCM (ArmAes)       | 128KB        | 184,210.5 ns | 452.86 ns | 423.60 ns |         - |
| Decrypt · AES-128-CCM (Managed)      | 128KB        | 736,430.0 ns | 459.91 ns | 430.20 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle) | 128KB        | 792,925.7 ns | 809.34 ns | 717.46 ns |    2424 B |
|                                      |              |              |           |           |           |
| Encrypt · AES-128-CCM (ArmAes)       | 128KB        | 183,919.0 ns | 630.04 ns | 589.34 ns |         - |
| Encrypt · AES-128-CCM (Managed)      | 128KB        | 736,115.3 ns | 191.11 ns | 169.41 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle) | 128KB        | 801,690.1 ns | 591.05 ns | 493.55 ns |    2464 B |