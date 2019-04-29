using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Storage;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            VirtuosoManager manager = new VirtuosoManager("localhost", VirtuosoManager.DefaultPort, VirtuosoManager.DefaultDB, "dba", "dba");
            IGraph g = new Graph();
            manager.LoadGraph(g,new Uri("http://localhost:8890/test"));
            INode ali = g.CreateUriNode(UriFactory.Create("http://bedrock/Ali"));
            INode hasParent = g.CreateUriNode(UriFactory.Create("http://bedrock/hasParent"));
            INode mullar = g.CreateUriNode(UriFactory.Create("http://bedrock/Mullar"));
            Triple t = new Triple(ali, hasParent, mullar);
            //g.Assert(t);
            foreach (Triple k in g.Triples)
            {
                Console.WriteLine(k.ToString());
            }
            Console.WriteLine(g.BaseUri);
            //manager.SaveGraph(g);          // to save updates happen to the graph
            //Console.WriteLine(g.IsEmpty);
            Console.ReadLine();

            //--------------------------------------------------Sparql query using sparql endPoint----------------------------//
            //SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://localhost:8890/sparql"), "http://localhost:8890/test");
            ////Make a SELECT query against the Endpoint
            //SparqlResultSet results = endpoint.QueryWithResultSet("SELECT ?grandParent WHERE { <http://bedrock/Ahmed> <http://bedrock/hasParent> ?o.  ?o <http://bedrock/hasParent> ?grandParent}");
            //foreach (SparqlResult result in results)
            //{
            //    Console.WriteLine(result.ToString());
            //}
            //Console.ReadLine();

        }
    }
}
