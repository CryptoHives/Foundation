| Description                                | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      28.03 ns |   0.074 ns |   0.069 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     583.91 ns |   0.668 ns |   0.625 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      34.46 ns |   0.089 ns |   0.084 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     608.90 ns |   0.916 ns |   0.857 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     133.44 ns |   0.542 ns |   0.507 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,311.32 ns |   3.660 ns |   3.423 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     142.95 ns |   0.647 ns |   0.605 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,332.10 ns |   3.157 ns |   2.953 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   1,034.98 ns |   4.678 ns |   4.376 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  15,994.88 ns |  42.023 ns |  39.308 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  16,326.38 ns |  86.115 ns |  80.552 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 254,335.36 ns | 439.096 ns | 410.731 ns |    1728 B |