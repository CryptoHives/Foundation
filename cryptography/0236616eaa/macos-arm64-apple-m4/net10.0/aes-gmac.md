| Description                                | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      59.32 ns |   0.297 ns |   0.263 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     579.69 ns |   2.791 ns |   2.474 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      66.96 ns |   0.224 ns |   0.187 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     602.14 ns |   0.256 ns |   0.227 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     582.05 ns |   1.274 ns |   1.192 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,292.78 ns |   4.087 ns |   3.823 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     592.33 ns |   1.579 ns |   1.399 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,318.98 ns |   1.848 ns |   1.729 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   4,982.21 ns |   0.939 ns |   0.784 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  15,966.37 ns |  22.451 ns |  18.748 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  79,952.45 ns |  16.893 ns |  13.189 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 253,741.03 ns | 116.345 ns | 108.829 ns |    1728 B |