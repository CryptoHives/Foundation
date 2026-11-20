| Description                                | TestDataSize | Mean          | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      52.75 ns |   0.099 ns |   0.083 ns |  18,489 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     525.87 ns |   1.844 ns |   1.725 ns |  22,214 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      58.21 ns |   0.113 ns |   0.094 ns |  22,238 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     540.40 ns |   3.584 ns |   2.798 ns |  26,617 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     146.38 ns |   0.314 ns |   0.294 ns |  22,660 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   1,447.97 ns |   2.264 ns |   2.007 ns |  22,227 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     152.10 ns |   0.082 ns |   0.068 ns |  22,529 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   1,445.79 ns |   3.202 ns |   2.674 ns |  22,770 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |     888.89 ns |   2.429 ns |   2.272 ns |  20,994 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |   8,724.88 ns |  17.213 ns |  15.259 ns |  26,109 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  13,641.75 ns |  30.638 ns |  28.659 ns |  18,879 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 140,105.70 ns | 284.962 ns | 252.612 ns |  26,339 B |    1816 B |