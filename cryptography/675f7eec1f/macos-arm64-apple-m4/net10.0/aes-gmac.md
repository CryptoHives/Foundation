| Description                                | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      59.70 ns |   0.245 ns |   0.230 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     653.10 ns |   1.177 ns |   1.101 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      66.99 ns |   0.676 ns |   0.633 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     677.73 ns |   0.544 ns |   0.509 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     586.94 ns |   2.506 ns |   2.344 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,337.96 ns |   2.532 ns |   2.368 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     597.95 ns |   2.774 ns |   2.595 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,364.72 ns |   1.576 ns |   1.474 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   5,016.76 ns |   2.427 ns |   2.270 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  15,690.60 ns |  19.131 ns |  17.895 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  80,489.74 ns |  95.346 ns |  89.187 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 247,987.78 ns | 702.130 ns | 656.773 ns |    1728 B |