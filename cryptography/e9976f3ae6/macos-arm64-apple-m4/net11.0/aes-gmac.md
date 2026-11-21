| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      30.03 ns |     0.081 ns |     0.076 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     576.64 ns |     1.787 ns |     1.672 ns |    1728 B |
|                                            |              |               |              |              |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      36.09 ns |     0.153 ns |     0.143 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     603.53 ns |     0.715 ns |     0.669 ns |    1728 B |
|                                            |              |               |              |              |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     131.79 ns |     0.822 ns |     0.729 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,289.45 ns |     7.989 ns |     7.082 ns |    1728 B |
|                                            |              |               |              |              |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     142.08 ns |     0.898 ns |     0.840 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,310.32 ns |    12.694 ns |    11.874 ns |    1728 B |
|                                            |              |               |              |              |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   1,007.20 ns |     4.029 ns |     3.572 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  15,973.60 ns |    52.316 ns |    48.936 ns |    1728 B |
|                                            |              |               |              |              |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  16,213.72 ns |    99.738 ns |    93.295 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 255,306.79 ns | 1,201.878 ns | 1,124.238 ns |    1728 B |