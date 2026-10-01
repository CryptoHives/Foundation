| Description                                | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      29.48 ns |   0.118 ns |   0.111 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     583.28 ns |   0.390 ns |   0.365 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      36.33 ns |   0.106 ns |   0.099 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     611.06 ns |   0.304 ns |   0.284 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     127.77 ns |   0.843 ns |   0.788 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,289.49 ns |   1.277 ns |   1.194 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     139.10 ns |   0.588 ns |   0.550 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,314.88 ns |   1.694 ns |   1.584 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |     997.44 ns |   4.672 ns |   4.370 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  15,919.97 ns |  20.681 ns |  19.345 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  15,651.30 ns |  95.839 ns |  89.647 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 251,492.77 ns | 933.016 ns | 872.744 ns |    1728 B |