| Description                                | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |     102.6 ns |   0.07 ns |   0.07 ns |  24,111 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |   1,014.4 ns |   1.74 ns |   1.54 ns |  22,194 B |    1816 B |
|                                            |              |              |           |           |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |     113.0 ns |   0.09 ns |   0.08 ns |  18,249 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |   1,043.4 ns |   3.16 ns |   2.64 ns |  22,713 B |    1816 B |
|                                            |              |              |           |           |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     234.0 ns |   0.23 ns |   0.22 ns |  22,964 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,652.9 ns |   1.45 ns |   1.21 ns |  26,037 B |    1816 B |
|                                            |              |              |           |           |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     244.9 ns |   0.59 ns |   0.55 ns |  18,783 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,691.3 ns |   4.73 ns |   4.42 ns |  26,583 B |    1816 B |
|                                            |              |              |           |           |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   1,313.7 ns |   5.03 ns |   4.71 ns |  22,543 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  15,455.0 ns |  17.80 ns |  16.65 ns |  22,217 B |    1816 B |
|                                            |              |              |           |           |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  19,775.3 ns |  40.60 ns |  37.98 ns |  22,212 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 236,856.0 ns | 268.86 ns | 251.49 ns |  26,505 B |    1816 B |