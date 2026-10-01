| Description                                | TestDataSize | Mean          | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      56.73 ns |   0.031 ns |   0.028 ns |  13,157 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     529.83 ns |   1.845 ns |   1.726 ns |  21,284 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      62.04 ns |   0.055 ns |   0.049 ns |  13,163 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     550.06 ns |   1.815 ns |   1.698 ns |  21,869 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     148.74 ns |   0.095 ns |   0.089 ns |  13,160 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   1,452.03 ns |   4.076 ns |   3.813 ns |  21,287 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     153.99 ns |   0.180 ns |   0.169 ns |  13,166 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   1,471.65 ns |   1.235 ns |   1.095 ns |  21,889 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |     892.06 ns |   0.648 ns |   0.575 ns |  13,160 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |   8,799.91 ns |   9.342 ns |   8.739 ns |  21,032 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  13,565.00 ns |   9.777 ns |   9.145 ns |  13,157 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 139,025.95 ns | 134.382 ns | 119.126 ns |  21,231 B |    1816 B |